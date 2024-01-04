// // using Microsoft.AspNetCore.Mvc;
// // using Microsoft.EntityFrameworkCore;
// // using dotnetapp.Models;
// // using System.Threading.Tasks;

// // namespace dotnetapp.Controllers
// // {
// //     public class TaskItemController : Controller
// //     {
// //         private readonly ApplicationDbContext _context;

// //         public TaskItemController(ApplicationDbContext context)
// //         {
// //             _context = context;
// //         }

// //         public async Task<IActionResult> Index(int? listId)
// //         {
// //             if (listId == null)
// //             {
// //                 return NotFound();
// //             }

// //             var taskList = await _context.TaskLists.Include(tl => tl.Tasks).FirstOrDefaultAsync(tl => tl.Id == listId);
// //             if (taskList == null)
// //             {
// //                 return NotFound();
// //             }

// //             return View(taskList.Tasks);
// //         }

// //         public IActionResult Create(int listId)
// //         {
// //             ViewData["TaskListId"] = listId;
// //             return View();
// //         }

// //         [HttpPost]
// //         [ValidateAntiForgeryToken]
// //         public async Task<IActionResult> Create([Bind("Id,Description,IsCompleted,TaskListId")] TaskItem taskItem)
// //         {
// //             if (ModelState.IsValid)
// //             {
// //                 _context.Add(taskItem);
// //                 await _context.SaveChangesAsync();
// //                 return RedirectToAction(nameof(Index), new { listId = taskItem.TaskListId });
// //             }
// //             ViewData["TaskListId"] = taskItem.TaskListId;
// //             return View(taskItem);
// //         }

// //         public async Task<IActionResult> Edit(int? id)
// //         {
// //             if (id == null)
// //             {
// //                 return NotFound();
// //             }

// //             var taskItem = await _context.TaskItems.FindAsync(id);
// //             if (taskItem == null)
// //             {
// //                 return NotFound();
// //             }
// //             return View(taskItem);
// //         }

// //         [HttpPost]
// //         [ValidateAntiForgeryToken]
// //         public async Task<IActionResult> Edit(int id, [Bind("Id,Description,IsCompleted,TaskListId")] TaskItem taskItem)
// //         {
// //             if (id != taskItem.Id)
// //             {
// //                 return NotFound();
// //             }

// //             if (ModelState.IsValid)
// //             {
// //                 try
// //                 {
// //                     _context.Update(taskItem);
// //                     await _context.SaveChangesAsync();
// //                 }
// //                 catch (DbUpdateConcurrencyException)
// //                 {
// //                     if (!TaskItemExists(taskItem.Id))
// //                     {
// //                         return NotFound();
// //                     }
// //                     else
// //                     {
// //                         throw;
// //                     }
// //                 }
// //                 return RedirectToAction(nameof(Index), new { listId = taskItem.TaskListId });
// //             }
// //             return View(taskItem);
// //         }

// //         public async Task<IActionResult> Delete(int? id)
// //         {
// //             if (id == null)
// //             {
// //                 return NotFound();
// //             }

// //             var taskItem = await _context.TaskItems
// //                 .FirstOrDefaultAsync(m => m.Id == id);
// //             if (taskItem == null)
// //             {
// //                 return NotFound();
// //             }

// //             return View(taskItem);
// //         }

// //         [HttpPost, ActionName("Delete")]
// //         [ValidateAntiForgeryToken]
// //         public async Task<IActionResult> DeleteConfirmed(int id)
// //         {
// //             var taskItem = await _context.TaskItems.FindAsync(id);
// //             _context.TaskItems.Remove(taskItem);
// //             await _context.SaveChangesAsync();
// //             return RedirectToAction(nameof(Index), new { listId = taskItem.TaskListId });
// //         }

// //         private bool TaskItemExists(int id)
// //         {
// //             return _context.TaskItems.Any(e => e.Id == id);
// //         }
// //     }
// // }


// // TaskItemController.cs
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// using dotnetapp.Models;
// using System.Threading.Tasks;

// namespace dotnetapp.Controllers
// {
//     public class TaskItemController : Controller
//     {
//         private readonly ApplicationDbContext _context;

//         public TaskItemController(ApplicationDbContext context)
//         {
//             _context = context;
//         }

//         public async Task<IActionResult> Index(int? listId)
//         {
//             if (listId == null)
//             {
//                 return NotFound();
//             }

//             var taskList = await _context.TaskLists.Include(tl => tl.Tasks).FirstOrDefaultAsync(tl => tl.Id == listId);
//             if (taskList == null)
//             {
//                 return NotFound();
//             }

//             return View(taskList.Tasks);
//         }

//         public IActionResult Create(int listId)
//         {
//             ViewData["TaskListId"] = listId;
//             return View();
//         }

//         [HttpPost]
//         [ValidateAntiForgeryToken]
//         public async Task<IActionResult> Create([Bind("Id,Description,IsCompleted,TaskListId")] TaskItem taskItem)
//         {
//             if (ModelState.IsValid)
//             {
//                 _context.Add(taskItem);
//                 await _context.SaveChangesAsync();
//                 return RedirectToAction(nameof(Index), new { listId = taskItem.TaskListId });
//             }
//             ViewData["TaskListId"] = taskItem.TaskListId;
//             return View(taskItem);
//         }

//         public async Task<IActionResult> Edit(int? id)
//         {
//             if (id == null)
//             {
//                 return NotFound();
//             }

//             var taskItem = await _context.TaskItems.FindAsync(id);
//             if (taskItem == null)
//             {
//                 return NotFound();
//             }
//             return View(taskItem);
//         }

//         [HttpPost]
//         [ValidateAntiForgeryToken]
//         public async Task<IActionResult> Edit(int id, [Bind("Id,Description,IsCompleted,TaskListId")] TaskItem taskItem)
//         {
//             if (id != taskItem.Id)
//             {
//                 return NotFound();
//             }

//             if (ModelState.IsValid)
//             {
//                 try
//                 {
//                     _context.Update(taskItem);
//                     await _context.SaveChangesAsync();
//                 }
//                 catch (DbUpdateConcurrencyException)
//                 {
//                     if (!TaskItemExists(taskItem.Id))
//                     {
//                         return NotFound();
//                     }
//                     else
//                     {
//                         throw;
//                     }
//                 }
//                 return RedirectToAction(nameof(Index), new { listId = taskItem.TaskListId });
//             }
//             return View(taskItem);
//         }

//         public async Task<IActionResult> Delete(int? id)
//         {
//             if (id == null)
//             {
//                 return NotFound();
//             }

//             var taskItem = await _context.TaskItems
//                 .FirstOrDefaultAsync(m => m.Id == id);
//             if (taskItem == null)
//             {
//                 return NotFound();
//             }

//             return View(taskItem);
//         }

//         [HttpPost, ActionName("Delete")]
//         [ValidateAntiForgeryToken]
//         public async Task<IActionResult> DeleteConfirmed(int id)
//         {
//             var taskItem = await _context.TaskItems.FindAsync(id);
//             _context.TaskItems.Remove(taskItem);
//             await _context.SaveChangesAsync();
//             return RedirectToAction(nameof(Index), new { listId = taskItem.TaskListId });
//         }

//         private bool TaskItemExists(int id)
//         {
//             return _context.TaskItems.Any(e => e.Id == id);
//         }
//     }
// }


using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dotnetapp.Models;
using System.Threading.Tasks;

namespace dotnetapp.Controllers
{
    public class TaskItemController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TaskItemController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Create(int listId)
        {
            ViewData["TaskListId"] = listId;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,IsCompleted,TaskListId")] TaskItem taskItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(taskItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), "TaskList");
            }
            ViewData["TaskListId"] = taskItem.TaskListId;
            return View(taskItem);
        }

        // Other actions for Edit, Delete, etc. as required

        private bool TaskItemExists(int id)
        {
            return _context.TaskItems.Any(e => e.Id == id);
        }
    }
}

