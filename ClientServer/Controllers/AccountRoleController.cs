using API.Models;
using API.Repositories.Interface;
using API.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AccountRoleController : ControllerBase
{
    private readonly IAccountRoleRepository _account_roleRepository;
    public AccountRoleController(IAccountRoleRepository account_roleRepository)
    {
        _account_roleRepository = account_roleRepository;
    }

    [HttpGet]
    public ActionResult GetAll()
    {
        var account_roles = _account_roleRepository.GetAll();
        //Handle ketika data tidak ada/ kosong
        if (account_roles == null)
            return NotFound(new ResponseErrorsVM<string>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Errors = "Data is Empty"
            });

        return Ok(new ResponseDataVM<IEnumerable<AccountRole>>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Success",
            Data = account_roles
        });
    }

    [HttpGet("{id}")]
    public ActionResult GetById(int id)
    {
        var account_role = _account_roleRepository.GetById(id);
        if (account_role == null)
            return NotFound(new ResponseErrorsVM<string>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Errors = "Id Not Found"
            });

        return Ok(new ResponseDataVM<AccountRole>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Success",
            Data = account_role
        });
    }

    [HttpPost]
    public ActionResult Insert(AccountRole account_role)
    {
        if (account_role.AccountNIK == "" || account_role.AccountNIK.ToLower() == "string")
        {
            return BadRequest(new ResponseErrorsVM<string>
            {
                Code = StatusCodes.Status400BadRequest,
                Status = HttpStatusCode.BadRequest.ToString(),
                Errors = "Value Cannot be Null or Default"
            });
        }

        if (account_role.RoleId == 0)
        {
            return BadRequest(new ResponseErrorsVM<string>
            {
                Code = StatusCodes.Status400BadRequest,
                Status = HttpStatusCode.BadRequest.ToString(),
                Errors = "Value Cannot be Null or Default"
            });
        }

        var insert = _account_roleRepository.Insert(account_role);
        if (insert > 0)
            return Ok(new ResponseDataVM<AccountRole>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Insert Success",
                Data = null!
            });

        return BadRequest(new ResponseErrorsVM<string>
        {
            Code = StatusCodes.Status500InternalServerError,
            Status = HttpStatusCode.InternalServerError.ToString(),
            Errors = "Insert Failed / Lost Connection"
        });
    }

    [HttpPut]
    public ActionResult Update(AccountRole account_role)
    {
        if (account_role.AccountNIK == "" || account_role.AccountNIK.ToLower() == "string")
        {
            return BadRequest(new ResponseErrorsVM<string>
            {
                Code = StatusCodes.Status400BadRequest,
                Status = HttpStatusCode.BadRequest.ToString(),
                Errors = "Value Cannot be Null or Default"
            });
        }

        if (account_role.RoleId == 0)
        {
            return BadRequest(new ResponseErrorsVM<string>
            {
                Code = StatusCodes.Status400BadRequest,
                Status = HttpStatusCode.BadRequest.ToString(),
                Errors = "Value Cannot be Null or Default"
            });
        }

        var update = _account_roleRepository.Update(account_role);
        if (update > 0)
            return Ok(new ResponseDataVM<University>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Update Success",
                Data = null!
            });

        return BadRequest(new ResponseErrorsVM<string>
        {
            Code = StatusCodes.Status500InternalServerError,
            Status = HttpStatusCode.InternalServerError.ToString(),
            Errors = "Update Failed / Lost Connection"
        });
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var delete = _account_roleRepository.Delete(id);
        if (delete > 0)
            return Ok(new ResponseDataVM<AccountRole>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Delete Success",
                Data = null!
            });

        return BadRequest(new ResponseErrorsVM<string>
        {
            Code = StatusCodes.Status500InternalServerError,
            Status = HttpStatusCode.InternalServerError.ToString(),
            Errors = "Delete Failed / Lost Connection"
        });
    }
}

