using Microsoft.AspNetCore.Mvc;
using TeamManagerWeb.Core.Entities;
using TeamManagerWeb.Repository.Common;

[Route("api/[controller]")]
[ApiController]
public class LanguageController : ControllerBase
{
    private readonly IRepository<Language, int> _languageRepository;

    public LanguageController(IRepository<Language, int> languageRepository)
    {
        _languageRepository = languageRepository;
    }

    [HttpPost]
    public async Task<ActionResult<Language>> AddLanguage(Language language)
    {
        try
        {
            await _languageRepository.CreateAsync(language);
            await _languageRepository.SaveAsync();
            return Ok(language);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Error adding language: {ex.Message}");
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Language>> EditLanguage(int id, Language language)
    {
        try
        {
            var existingLanguage = await _languageRepository.GetAsync(id);
            if (existingLanguage == null)
            {
                return NotFound($"Language with id {id} not found");
            }

            existingLanguage.Name = language.Name;
            await _languageRepository.UpdateAsync(existingLanguage);
            await _languageRepository.SaveAsync();

            return Ok(existingLanguage);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Error updating language: {ex.Message}");
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> DeleteLanguage(int id)
    {
        try
        {
            var existingLanguage = await _languageRepository.GetAsync(id);
            if (existingLanguage == null)
            {
                return NotFound($"Language with id {id} not found");
            }

            await _languageRepository.DeleteAsync(id);
            await _languageRepository.SaveAsync();

            return Ok(true);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Error deleting language: {ex.Message}");
        }
    }

    [HttpGet]
    public async Task<ActionResult<List<Language>>> GetAllLanguages()
    {
        try
        {
            var languages = await _languageRepository.GetAllAsync();
            return Ok(languages);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving languages: {ex.Message}");
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Language>> GetLanguageById(int id)
    {
        try
        {
            var language = await _languageRepository.GetAsync(id);
            if (language == null)
            {
                return NotFound($"Language with id {id} not found");
            }
            return Ok(language);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving language: {ex.Message}");
        }
    }
}