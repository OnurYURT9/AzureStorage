
using AzureStorageLibrary.Services;
using System.Text;
namespace QueueConsoleApp
{
    internal class Program
    {
        private async static Task Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            AzureStorageLibrary.ConnectionStrings.AzureStorageConnectionString = "DefaultEndpointsProtocol=https;AccountName=udemyazurestoragea;AccountKey=J2EiBqfj7M9OE7iqlC9mbOdNpazNSfivlHAFlfBY2dcukxbCMTy8mkABEinTXUpH1dVjvCn+0fTw+AStJqRB9A==;EndpointSuffix=core.windows.net";
            AzQueue queue = new AzQueue("ornekkuyruk");
            //string base64message = Convert.ToBase64String(Encoding.UTF8.GetBytes("Onur Yurt"));
            ////queue.SendMessageAsync(base64message).Wait();

            var message = queue.RetrieveNextMessageAsync().Result;
            //string text =Encoding.UTF8.GetString(Convert.FromBase64String(message.MessageText));
            //Console.WriteLine("Mesaj:"+text);
            await queue.DeleteMessage(message.MessageId,message.PopReceipt);
            Console.WriteLine("Mesaj silindi");
        }

    }
  
}


