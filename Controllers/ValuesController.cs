using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using YoutubeExplode;
using YoutubeExplode.Models.MediaStreams;


namespace DangTai.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetAsync(string id)
        {

         var client = new YoutubeClient(); //This should be initialized in YoutubeController constructor.
            var mediaInfoSet = await client.GetVideoMediaStreamInfosAsync(id);
            var mediaStreamInfo = mediaInfoSet.Audio.WithHighestBitrate();
            var mimeType = $"audio/{mediaStreamInfo.Container.GetFileExtension()}";
            var fileName = $"{id}.{mediaStreamInfo.Container.GetFileExtension()}";
            return File(await client.GetMediaStreamAsync(mediaStreamInfo), mimeType, fileName, true);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
