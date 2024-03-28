using VaultSharp;
using VaultSharp.V1.AuthMethods.Token;

namespace PolicyAPI.Configurations
{
    public class VaultConfiguration
    {
        private IConfiguration _configuration;

        public VaultConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public async Task<Dictionary<string,object>>  GetSecrets()
        {
            var url = _configuration["Vault_Url"];
            var rootToken = _configuration["Root_Token"];

            TokenAuthMethodInfo tokenAuthMethodInfo=
                new TokenAuthMethodInfo(rootToken);

           VaultClientSettings  vaultClientSettings
                =new VaultClientSettings(url, tokenAuthMethodInfo);
            IVaultClient vaultClient = new VaultClient(vaultClientSettings);
            Console.WriteLine(vaultClient.V1.Secrets);

            var result = await vaultClient.V1.Secrets.KeyValue.V1.ReadSecretAsync("sqlserver2019",
                "secret", null);
            return result.Data;


        }
    }
}
