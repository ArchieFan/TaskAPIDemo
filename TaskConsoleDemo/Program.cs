namespace AsynchronousProgramming
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Main Method Started......");
            Console.WriteLine("Enter the Name: ");
            string? Name = Console.ReadLine();
            SomeMethod(Name!);
            Console.WriteLine("Main Method End");
            Console.ReadKey();
        }
        public async static void SomeMethod(string Name)
        {
            Console.WriteLine("Some Method Started......");
            try
            {
                var GreetingSMessage = await Greetings(Name);
                Console.WriteLine($"\n{GreetingSMessage}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError Occurred. {ex.Message}");
            }
            Console.WriteLine("Some Method End");
        }

        public static async Task<string> Greetings(string Name)
        {
            string message = string.Empty;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5257/");

                HttpResponseMessage response = await client.GetAsync($"api/greetings2/{Name}");
                response.EnsureSuccessStatusCode();
                message = await response.Content.ReadAsStringAsync();
            }
            return message;
        }
    }
}
