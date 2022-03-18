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
using UniClub.HttpApi.Models;

namespace UniClub.HttpApi.ApiControllers.V1
{
    [ApiController]
    [Route("api/v1/club-periods/cpid/[controller]")]
    public class ClubMembersController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetClubMembersWithPagination(int cpid, [FromQuery] GetClubMembersWithPaginationDto query)
        {
            try
            {
                query.SetClubPeriodId(cpid);
                var result = await Mediator.Send(query);
                return Ok(new ResponseResult() { Data = result, StatusCode = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult() { StatusCode = HttpStatusCode.InternalServerError, Data = ex.Message });
            }
        }

        [HttpGet("{id}", Name = "GetClubMember")]
        public async Task<IActionResult> GetClubMemberById(int cpid, string id)
        {
            try
            {
                var query = new GetClubMemberByIdDto(id);
                query.SetClubPeriodId(cpid);
                var result = await Mediator.Send(query);
                return result != null ? Ok(new ResponseResult() { Data = result, StatusCode = HttpStatusCode.OK })
                    : NotFound(new ResponseResult() { Data = $"Member {id} is not found", StatusCode = HttpStatusCode.NotFound });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult() { StatusCode = HttpStatusCode.InternalServerError, Data = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateClubMember(int cpid, [FromBody] CreateClubMemberDto command)
        {
            try
            {
                command.SetClubPeriodId(cpid);
                var result = await Mediator.Send(command);
                return CreatedAtRoute(nameof(GetClubMemberById), new { id = result }, command);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult() { StatusCode = HttpStatusCode.InternalServerError, Data = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClubMember(int cpid, string id, [FromBody] UpdateClubMemberDto command)
        {
            try
            {
                if (command.MemberId.Equals(id))
                {
                    command.SetClubPeriodId(cpid);
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
        public async Task<IActionResult> RecoverClubMember(int cpid, string id, [FromBody] RecoverClubMemberDto command)
        {
            try
            {
                if (command.MemberId.Equals(id))
                {
                    command.SetClubPeriodId(cpid);
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
        public async Task<IActionResult> DeleteClubMember(int cpid, string id)
        {
            try
            {
                var command = new DeleteClubMemberDto(cpid, id);
                var result = await Mediator.Send(command);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult() { StatusCode = HttpStatusCode.InternalServerError, Data = ex.Message });
            }
        }

    }
}

