using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace VL.UnityStarter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            new MyTester().Test();
            Console.ReadLine();
        }
    }
}

public class MyTester
{
    public async Task<bool> Test()
    {
        try
        {
            var client = new ChatGPTClient("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");
            var response = await client.GenerateResponseAsync("Hi, how are you?", 50, 0.5);
            Console.WriteLine(response.text);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
        return true;
    }
}
public class ChatGPTRequest
{
    public string prompt { get; set; }
    public int max_tokens { get; set; }
    public double temperature { get; set; }
    // 其他可选参数
}

public class ChatGPTResponse
{
    public string text { get; set; }
    // 其他响应信息
}

public class ChatGPTClient
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;

    public ChatGPTClient(string apiKey)
    {
        _httpClient = new HttpClient();
        _apiKey = apiKey;
    }

    public async Task<ChatGPTResponse> GenerateResponseAsync(string prompt, int maxTokens, double temperature)
    {
        var apiUrl = "https://api.chatgpt.com/generate";
        var requestData = new ChatGPTRequest
        {
            prompt = prompt,
            max_tokens = maxTokens,
            temperature = temperature,
            // 可选参数
        };
        var jsonRequestData = JsonConvert.SerializeObject(requestData);
        var content = new StringContent(jsonRequestData, Encoding.UTF8, "application/json");
        _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");
        var response = await _httpClient.PostAsync(apiUrl, content);
        var jsonResponseData = await response.Content.ReadAsStringAsync();
        var responseData = JsonConvert.DeserializeObject<ChatGPTResponse>(jsonResponseData);
        return responseData;
    }
}


public class TestEntrance: TestFloor
{
    public TestEntrance(string name) : base(name)
    {
    }

    public bool IsEntrance { get; set; }
}
public class TestFloor
{
    public TestFloor(string name)
    {
        Name = name;
    }

    public string Name { get; set; }
}
