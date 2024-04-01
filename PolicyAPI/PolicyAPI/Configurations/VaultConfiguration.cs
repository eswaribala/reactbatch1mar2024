using VaultSharp;
using VaultSharp.V1.AuthMethods.Token;
using VaultSharp.V1.Commons;

namespace PolicyAPI.Configurations
{
    public class VaultConfiguration
    {
        private IConfiguration _configuration;

        public VaultConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public async Task<IDictionary<string,object>>  GetSecrets(string Url, string RootKey)
        {

            TokenAuthMethodInfo tokenAuthMethodInfo=
                new TokenAuthMethodInfo(RootKey);

           VaultClientSettings  vaultClientSettings
                =new VaultClientSettings(Url, tokenAuthMethodInfo);
            IVaultClient vaultClient = new VaultClient(vaultClientSettings);
            Console.WriteLine(vaultClient.V1.Secrets);

            //var result = await vaultClient.V1.Secrets.KeyValue.V1.ReadSecretAsync("sqlserver2019",
            //   "secret", null);

            var result = vaultClient.V1.Secrets.KeyValue.
             V2.ReadSecretAsync(path: "sqlserver2019", mountPoint: "secret").Result.Data.Data;


            return result;



        }
    }
}
