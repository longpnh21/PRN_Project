using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;
using UniClub.Dtos.Create;
using UniClub.Dtos.Delete;
using UniClub.Dtos.GetById;
using UniClub.Dtos.GetWithPagination;
using UniClub.Dtos.Recover;
using UniClub.Dtos.Update;
using UniClub.HttpApi.ApiControllers;
using UniClub.HttpApi.Models;

[ApiController]
[Route("api/v1/[controller]")]
public class UniversitiesController : ApiControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetUniversitiesWithPagination([FromQuery] GetUniversitiesWithPaginationDto query)
    {
        try
        {
            var result = await Mediator.Send(query);
            return Ok(new ResponseResult() { Data = result, StatusCode = HttpStatusCode.OK });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new ResponseResult() { StatusCode = HttpStatusCode.InternalServerError, Data = ex.Message });
        }
    }

    [HttpGet("{id}", Name = "GetUniversity")]
    public async Task<IActionResult> GetUniversity(int id)
    {
        try
        {
            var query = new GetUniversityByIdDto(id);
            var result = await Mediator.Send(query);
            return result != null ? Ok(new ResponseResult() { Data = result, StatusCode = HttpStatusCode.OK })
                : NotFound(new ResponseResult() { Data = $"University {id} is not found", StatusCode = HttpStatusCode.NotFound });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new ResponseResult() { StatusCode = HttpStatusCode.InternalServerError, Data = ex.Message });
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateUniversity([FromForm] CreateUniversityDto command)
    {
        try
        {
            var result = await Mediator.Send(command);
            return CreatedAtRoute(nameof(GetUniversity), new { id = result }, command);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new ResponseResult() { StatusCode = HttpStatusCode.InternalServerError, Data = ex.Message });
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUniversity(int id, [FromForm] UpdateUniversityDto command)
    {
        try
        {
            if (command.Id.Equals(id))
            {
                var result = await Mediator.Send(command);
                return NoContent();
            }
            else
            {
                return BadRequest(new ResponseResult() { StatusCode = HttpStatusCode.BadRequest, Data = "Invalid object" });
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, new ResponseResult() { StatusCode = HttpStatusCode.InternalServerError, Data = ex.Message });
        }
    }

    [HttpPut("{id}/recover")]
    public async Task<IActionResult> RecoverUniversity(int id, [FromBody] RecoverUniversityDto command)
    {
        try
        {
            if (command.Id.Equals(id))
            {
                var result = await Mediator.Send(command);
                return NoContent();
            }
            else
            {
                return BadRequest(new ResponseResult() { StatusCode = HttpStatusCode.BadRequest, Data = "Invalid object" });
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, new ResponseResult() { StatusCode = HttpStatusCode.InternalServerError, Data = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUniversity(int id)
    {
        try
        {
            var command = new DeleteUniversityDto(id);
            var result = await Mediator.Send(command);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, new ResponseResult() { StatusCode = HttpStatusCode.InternalServerError, Data = ex.Message });
        }
    }
}
