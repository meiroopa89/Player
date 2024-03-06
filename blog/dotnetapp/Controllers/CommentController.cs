// CommentController.cs
using Microsoft.AspNetCore.Mvc;
using dotnetapp.Model;
using dotnetapp.Services;

namespace dotnetapp.Controllers
{
[Route("api/posts/{postId}/comments")]
[ApiController]
public class CommentController : ControllerBase
{
    private readonly ICommentService _commentService;

    public CommentController(ICommentService commentService)
    {
        _commentService = commentService;
    }

    [HttpGet]
    public IActionResult GetAllComments(int postId)
    {
        var comments = _commentService.GetAllComments(postId);
        return Ok(comments);
    }

    [HttpGet("{commentId}")]
    public IActionResult GetComment(int postId, int commentId)
    {
        var comment = _commentService.GetComment(commentId);
        if (comment == null)
            return NotFound();

        return Ok(comment);
    }

    [HttpPost]
    public IActionResult AddComment(int postId, [FromBody] Comment comment)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        _commentService.SaveComment(postId, comment);
        return Created($"/api/posts/{postId}/comments/{comment.Id}", comment);
    }

    
    [HttpPut("{commentId}")]
    public IActionResult UpdateComment(int postId, int commentId, [FromBody] Comment updatedComment)
    {
        var result = _commentService.UpdateComment(commentId, updatedComment);
        if (result == null)
            return NotFound();

        return Ok(result);
    }
    [HttpDelete("{commentId}")]
    public IActionResult DeleteComment(int postId, int commentId)
    {
        var existingComment = _commentService.GetComment(commentId);
        if (existingComment == null)
            return NotFound();

        _commentService.DeleteComment(commentId);
        return NoContent();
    }
}
}
