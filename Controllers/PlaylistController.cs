using System;
using Microsoft.AspNetCore.Mvc;
using MongoExample.Services;
using MongoExample.Models;



namespace MongoExample.Controllers;
[Controller]
[Route("api/[controller]")]
public class PlaylistController : Controller{

    private readonly MongoDBService _mongoDBService;

    public PlaylistController(MongoDBService mongoDBService){
        _mongoDBService = mongoDBService;
    }

   [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Playlist))]
    [ProducesResponseType(StatusCodes.Status404NotFound)] //* se explanation below in developer notes
    public async Task<List<Playlist>> Get() {
        return await _mongoDBService.GetAsync();
    }

   [HttpPost]
    public async Task<IActionResult> Post([FromBody] Playlist playlist) {
        await _mongoDBService.CreateAsync(playlist);
        return CreatedAtAction(nameof(Get), new {id = playlist.Id}, playlist); //returns Created (201)
    }

    [HttpPut("{id}")] 
    public async Task<IActionResult> AddToPlaylist(string id, [FromBody] string movieId) {
        await _mongoDBService.AddToPlaylistAsync(id, movieId);
        return NoContent(); //status 204 No Content, or Ok() status code 200;
    }

 
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete (string id) {
        await _mongoDBService.DeleteAsync(id);
        return NoContent(); 
    }




}