using Azure;
using Azure.Data.Tables;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

public class AzureTableStorageModel : PageModel
{
    private readonly IConfiguration _configuration;
    public List<TableEntity> TableEntities { get; set; }

    public AzureTableStorageModel(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void OnGet()
    {
        string connectionString = _configuration["AzureTableStorageConnectionString"];
        TableServiceClient tableServiceClient = new TableServiceClient(connectionString);
        TableClient tableClient = tableServiceClient.GetTableClient("YourTableName");

        Pageable<TableEntity> queryResults = tableClient.Query<TableEntity>();
        TableEntities = queryResults.ToList();
    }
}
