using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NewAppRequest.Pages.AppRequest
{
    public class AppRequestModel : PageModel
    {
        [BindProperty]
        public AppRequest appRequest { get; set; }

        HttpClient _client = new HttpClient();
        private string baseAPIURL = "http://localhost:42307";
        public void OnGet()
        {
        }

        public void OnPost()
        {
            var jsonstring = JsonConvert.SerializeObject(appRequest);
            var stringContent = new StringContent(jsonstring, UnicodeEncoding.UTF8, "application/json");

            var response = _client.PostAsync(baseAPIURL + "/AppRequest/AddNewAppRequest", stringContent);
            response.Wait();
            var test = response.Result;

            if(test.IsSuccessStatusCode)
            {
                //appRequest = test.Content.ReadAsAsync<AppRequest>();
            }


            //var jsonstring = JsonConvert.SerializeObject(appRequest);
            //var stringContent = new StringContent(jsonstring, UnicodeEncoding.UTF8, "application/json");
            //await restinterface.PostAsync("/AppRequest/AddNewAppRequest", stringContent);
        }
    }


    public class AppRequest
    {
        public int requestId { get; set; }

        [Required]
        [MaxLength(20)]
        public string? firstName { get; set; }

        [Required]
        [MaxLength(20)]
        public string? lastName { get; set; }

        [Required]
        [MaxLength(30)]
        public string? email { get; set; }

        [Required]
        [MaxLength(12)]
        public string? phoneNumber { get; set; }

        [Required]
        [MaxLength(30)]
        [Display(Name="Application Name")]
        public string? applicationName { get; set; }

        [Required]
        [MaxLength(30)]
        [Display(Name = "Application URL")]
        public string? applicationURL { get; set; }

        [MaxLength(16)]
        public string? memberId { get; set; }

        [MaxLength(6)]
        public string? groupId { get; set; }

        [MaxLength(1)]
        public string? suffix { get; set; }

        [MaxLength(100)]
        public string? usercomments { get; set; }

        public string? requesteddate { get; set; }

        public string? status { get; set; }

        public string? isadmin { get; set; }

        public string? userid { get; set; }

        public string? contactedstatus { get; set; }

        public string? notes { get; set; }
    }
}
