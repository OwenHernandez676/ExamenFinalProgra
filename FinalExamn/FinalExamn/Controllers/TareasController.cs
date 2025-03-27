using FinalExamn.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class TareasController : ControllerBase
{
    private readonly TareaService _tareaService;

    public TareasController(TareaService tareaService)
    {
        _tareaService = tareaService;
    }

    // GET: api/tareas
    [HttpGet]
    public async Task<IActionResult> GetTareas()
    {
        var tareas = await _tareaService.GetAllAsync();
        return Ok(tareas);
    }

    // POST: api/tareas
    [HttpPost]
    public async Task<IActionResult> CrearTarea([FromBody] Tarea tarea)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var creado = await _tareaService.CreateAsync(tarea);
        return CreatedAtAction(nameof(GetTareas), new { id = creado.Id }, creado);
    }

    // PUT: api/tareas/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> ActualizarTarea(int id, [FromBody] Tarea tarea)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        // Validar que el id de la URL coincida con el id de la tarea enviada
        if (id != tarea.Id)
            return BadRequest("El ID de la tarea no coincide con el de la URL.");

        var tareaActualizada = await _tareaService.UpdateAsync(tarea);
        if (tareaActualizada == null)
            return NotFound();

        return Ok(tareaActualizada);
    }

    // DELETE: api/tareas/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> EliminarTarea(int id)
    {
        var eliminado = await _tareaService.DeleteAsync(id);
        if (!eliminado)
            return NotFound();

        return NoContent();
    }
}
