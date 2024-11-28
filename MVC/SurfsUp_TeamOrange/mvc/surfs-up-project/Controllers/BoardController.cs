using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using surfs_up_project.Models;


namespace surfs_up_project.Controllers
{
    public class BoardController : Controller
    {
        private readonly string apiUrl = "https://localhost:7010/api/"; // 7010 is defined when creating project
        public async Task<IActionResult> Boards()
        {
            List<Board>? products = [];
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(apiUrl + "rental/boards/"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string payload = await response.Content.ReadAsStringAsync();
                        products = JsonConvert.DeserializeObject<List<Board>>(payload);
                    }
                    else
                    {
                        return BadRequest($"API request failed with status code {response.StatusCode}");
                    }
                }
            }
            return View(products);
        }

        public IActionResult Board(int? id)
        {
            var board = ProductRepository.GetById(id);
            return View(board);
        }

        //public IActionResult Wetsuit(int? id)
        //{
        //    var board = ProductRepository.GetProductById(id);
        //    return View(board);
        //}

        //public IActionResult Equipment(int? id)
        //{
        //    var board = ProductRepository.GetProductById(id);
        //    return View(board);
        //}
    }
}
