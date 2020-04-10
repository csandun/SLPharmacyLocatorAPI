using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Google.Maps;
using Google.Maps.Geocoding;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SLPharmacyLocatorAPI.Models;

namespace SLPharmacyLocatorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PharmaciesController : ControllerBase
    {
        DefaultDbContext DefaultDbContext;
        public PharmaciesController(DefaultDbContext defaultDbContext)
        {
            this.DefaultDbContext = defaultDbContext;
        }


        [HttpGet]
        [Route("Grab")]
        public async Task<IActionResult> GrabData()
        {
            var list = this.GetListFromFile();

            GoogleSigned.AssignAllServices(new GoogleSigned("AIzaSyBv0Vd7xkiUyHFXML57OzqwR8bK1ujHxB8"));
            int a = 1;
            foreach (var item in list)
            {
                var request = new GeocodingRequest();
                request.Address = item.Name + ", " + item.Address;
                var response = new GeocodingService().GetResponse(request);
                if (response.Status == ServiceResponseStatus.Ok && response.Results.Count() > 0)
                {
                    var result = response.Results.First();
                    item.Latitude = result.Geometry.Location.Latitude;
                    item.Longitude = result.Geometry.Location.Longitude;
                }
                else
                {
                    Console.WriteLine("Unable to geocode.  Status={0} and ErrorMessage={1}", response.Status, response.ErrorMessage);
                }

                await this.DefaultDbContext.Pharmacy.AddAsync(item);
                await this.DefaultDbContext.SaveChangesAsync();

                a++;
            }

            return Ok();
        }

        private List<Pharmacy> GetListFromFile()
        {

            // Read entire text file content in one string    
            string text = System.IO.File.ReadAllText(@"E:\phamacyfile\list.json");
            var list = JsonConvert.DeserializeObject<List<Pharmacy>>(text);
            return list;
        }


        [HttpGet]        
        public async Task<IActionResult> get()
        {            
            string text = System.IO.File.ReadAllText("./GovPharmacyList.json");
            var list = JsonConvert.DeserializeObject<List<Pharmacy>>(text);
            return Ok(list);
        }


    }
}
