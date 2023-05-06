using API.Models;
using API.Repositories.Interface;
using API.Base;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UniversityController : GeneralController<IUniversityRepository, University, int>
{
    public UniversityController(IUniversityRepository repository) : base(repository) { }
    
}
