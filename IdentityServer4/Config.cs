using IdentityServer4.Models;

namespace IdentityServer4Center
{
    public static class Config
    {
        /// <summary>
        /// 定义API范围
        /// </summary>
        public static IEnumerable<ApiScope> ApiScopes =>
        new List<ApiScope>
        {
           new ApiScope("serviceA"),
           new ApiScope("serviceB")
        };

        /// <summary>
        /// 定义API资源
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>()
            {
                new ApiResource("serviceA","serviceA"){ Scopes={ "serviceA" } },
                new ApiResource("serviceB","serviceB"){ Scopes={ "serviceB" } }
            };
        }


        /// <summary>
        /// 定义客户端
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
               new Client{
                   ClientId="web_client",//客户端唯一标识
                   ClientName="AuthCenter",
                   //AllowedGrantTypes=new List<string>{ "paas_password", "paas_auth_code", "client_credentials"},
                   AllowedGrantTypes=GrantTypes.ClientCredentials,
                   ClientSecrets=new[]{new Secret("fengzhonghao123456".Sha256()) },//客户端密码，进行了加密
                   AccessTokenLifetime=3600,
                   AllowedScopes=new List<string>//允许访问的资源
                   {
                        "serviceA",
                        "serviceB"
                   },
                   Claims=new List<ClientClaim>(){
                   new ClientClaim(IdentityModel.JwtClaimTypes.Role,"Admin"),
                   new ClientClaim(IdentityModel.JwtClaimTypes.NickName,"Mamba24"),
                   }
               }
            };
        }
    }
}
