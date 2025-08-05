using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoList.Models;
using TaskModel = ToDoList.Models.Task;
using System.Threading.Tasks;

namespace ToDoList.Controllers
{
    // Controlador responsável pelo CRUD de tarefas
    public class TasksController : Controller
    {
        private readonly AppDbContext _context;

        public TasksController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /Tasks
        public async Task<IActionResult> Index()
        {
            var tasks = await _context.Tasks.OrderByDescending(t => t.CreatedAt).ToListAsync();
            return View(tasks);
        }

        // GET: /Tasks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Tasks/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TaskModel task)
        {
            if (ModelState.IsValid)
            {
                task.UpdatedAt = DateTime.MinValue;
                _context.Add(task);
                await _context.SaveChangesAsync();
                // Log de criação de tarefa (padrão júnior)
                Console.WriteLine($"[LOG] Tarefa criada: {task.Title} (ID: {task.Id})");
                TempData["SuccessMessage"] = "TaskCreatedSuccess";
                return RedirectToAction(nameof(Index));
            }
            TempData["ErrorMessage"] = "TaskCreateError";
            return View(task);
        }

        // GET: /Tasks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var task = await _context.Tasks.FindAsync(id);
            if (task == null) return NotFound();
            return View(task);
        }

        // POST: /Tasks/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TaskModel task)
        {
            if (id != task.Id) return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    task.UpdatedAt = DateTime.UtcNow;
                    _context.Update(task);
                    await _context.SaveChangesAsync();
                    // Log de edição de tarefa
                    Console.WriteLine($"[LOG] Tarefa editada: {task.Title} (ID: {task.Id})");
                    TempData["SuccessMessage"] = "TaskEditedSuccess";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Tasks.Any(e => e.Id == task.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            TempData["ErrorMessage"] = "TaskEditError";
            return View(task);
        }

        // GET: /Tasks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var task = await _context.Tasks.FindAsync(id);
            if (task == null) return NotFound();
            return View(task);
        }

        // POST: /Tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                await _context.SaveChangesAsync();
                // Log de exclusão de tarefa
                Console.WriteLine($"[LOG] Tarefa excluída: {task.Title} (ID: {task.Id})");
                TempData["SuccessMessage"] = "TaskDeletedSuccess";
            }
            else
            {
                TempData["ErrorMessage"] = "TaskDeleteNotFound";
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: /Tasks/ToggleComplete/5
        [HttpPost]
        public async Task<IActionResult> ToggleComplete(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
                return NotFound();
            task.IsCompleted = !task.IsCompleted;
            if (task.IsCompleted)
            {
                task.CompletedAt = DateTime.UtcNow;
            }
            else
            {
                task.CompletedAt = null;
            }
            await _context.SaveChangesAsync();
            // Formatar as datas no padrão dd/MM/yyyy HH:mm (UTC-3)
            string? completedAtStr = null;
            if (task.CompletedAt.HasValue)
            {
                completedAtStr = task.CompletedAt.Value.AddHours(-3).ToString("dd/MM/yyyy HH:mm:ss");
            }
            string updatedAtStr = task.UpdatedAt > DateTime.MinValue
                ? task.UpdatedAt.AddHours(-3).ToString("dd/MM/yyyy HH:mm:ss")
                : "-";
            return Json(new { success = true, isCompleted = task.IsCompleted, completedAt = completedAtStr, updatedAt = updatedAtStr });
        }
    }
}
