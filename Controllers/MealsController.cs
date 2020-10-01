using System.Collections.Generic;
using AutoMapper;
using MealApp.Data;
using MealApp.Dtos;
using MealApp.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace MealApp.Controllers
{

    //api/Meals
    [Route("api/Meals")]
    [ApiController]
    public class MealsController : ControllerBase
    {

        private readonly IMealRepo _repository;
        private readonly IMapper _mapper;

        public MealsController(IMealRepo repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
        //GET api/Meals
        [HttpGet]
        public ActionResult<IEnumerable<MealReadDto>> GetAllMeals()
        {
            var MealItems = _repository.GetAllMeals();
            return Ok(_mapper.Map<IEnumerable<MealReadDto>>(MealItems));
        }
        
        //GET api/Meals/{id}

        [HttpGet("{id}", Name="GetMealById")]
        public ActionResult <MealReadDto> GetMealById(int id)
        {
            var MealItem = _repository.GetMealById(id);
            if (MealItem != null)
            {
                return Ok(_mapper.Map<MealReadDto>(MealItem));
            }
            return NotFound();
        }

        //POST api/Meals
        [HttpPost]
        public ActionResult<MealCreateDto> CreateMeal(MealCreateDto MealCreateDto)
        {
            var MealModel = _mapper.Map<Meal>(MealCreateDto);
            _repository.CreateMeal(MealModel);
            _repository.SaveChanges();

            var MealReadDto = _mapper.Map<MealReadDto>(MealModel);
            //return Ok(MealReadDto);
            return CreatedAtRoute(nameof(GetMealById), new {Id = MealReadDto.Id}, MealReadDto);
        }

        //PUT api/Meals/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateMeal(int id, MealUpdateDto MealUpdateDto)
        {
            var MealModelFromRepo = _repository.GetMealById(id);
            if(MealModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(MealUpdateDto, MealModelFromRepo);

            _repository.UpdateMeal(MealModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
            }

        //PATCH api/Meals/{id}
        [HttpPatch ("{id}")]
        public ActionResult PartialMealUpdate(int id, JsonPatchDocument<MealUpdateDto> pathDoc)
        {
            var MealModelFromRepo = _repository.GetMealById(id);
            if(MealModelFromRepo == null)
            {
                return NotFound();
            }

            var MealToPatch = _mapper.Map<MealUpdateDto>(MealModelFromRepo);
            pathDoc.ApplyTo(MealToPatch, ModelState);
            if(!TryValidateModel(MealToPatch))
            {
                return ValidationProblem(ModelState);
            }
            
             _mapper.Map(MealToPatch, MealModelFromRepo);
             _repository.UpdateMeal(MealModelFromRepo);
             _repository.SaveChanges();
             return NoContent();

        }

         //DELETE api/Meals/{id}
        [HttpDelete ("{id}")]
            public ActionResult DeleteMeal(int id)
            {
                var MealModelFromRepo = _repository.GetMealById(id);
                if(MealModelFromRepo == null)
                    {
                        return NotFound();
                    }
                    _repository.DeleteMeal(MealModelFromRepo);
                    _repository.SaveChanges();
                    return NoContent();
            }
        
        
    }
}