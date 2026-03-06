using APIsNET.Application.ViewModel;
using APIsNET.Domain.DTOs;
using APIsNET.Domain.Model.EmployeeAggregate;
using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APIsNET.Controllers.v2
{
    [ApiVersion("2.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/employee")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILogger<EmployeeController> _logger;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeRepository employeeRepository, ILogger<EmployeeController> logger, IMapper mapper)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [Authorize]
        [HttpPost]
        public IActionResult Add([FromForm] EmployeeViewModel employeeView)
        {
            var filePath = Path.Combine("Storage", employeeView.Photo.FileName);

            using Stream fileStream = new FileStream(filePath, FileMode.Create);
            employeeView.Photo.CopyTo(fileStream);

            var employee = new Employee(employeeView.Name, employeeView.Age, filePath);

            _employeeRepository.Add(employee);
            return Ok();
        }

        [Authorize]
        [HttpPost]
        [Route("{id}/download")]
        public IActionResult DownloadPhoto(int id)
        {
            var employee = _employeeRepository.Get(id);

            var dataBytes = System.IO.File.ReadAllBytes(employee.photo);

            return File(dataBytes, "image/png");
        }

        //[Authorize]
        [HttpGet]
        public IActionResult Get(int pageNumber, int pageQuantity)
        {
            _logger.Log(LogLevel.Error, "Aconteceu um erro");

            var employees = _employeeRepository.Get(pageNumber, pageQuantity);

            _logger.LogInformation("Teste apenas");

            return Ok(employees);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Search(int id)
        {
            var employees = _employeeRepository.Get(id);

            var _employeesDTOS = _mapper.Map<EmployeeDTO>(employees);

            return Ok(_employeesDTOS);
        }
    }
}
