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
        public async Task<ActionResult<MuxedStreamInfo>> GetAsync(string id)
        {

            var client = new YoutubeClient();

            // Get metadata for all streams in this video
            var streamInfoSet = await client.GetVideoMediaStreamInfosAsync(id);

            // Select one of the streams, e.g. highest quality muxed stream
            var streamInfo = streamInfoSet.Muxed.WithHighestVideoQuality();


            //var ext = streamInfo.Container.GetFileExtension();

            // Download stream to file
          //  await client.DownloadMediaStreamAsync(streamInfo, $"downloaded_video.{ext}");


            return streamInfo;
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
