import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { TaskService } from '../services/task.service';
import { Task } from '../model/task.model';

@Component({
  selector: 'app-task-list',
  templateUrl: './task-list.component.html',
  styleUrls: ['./task-list.component.css']
})
export class TaskListComponent implements OnInit {
  tasks$: Observable<Task[]>;
  selectedTask: Task | null = null;
  newTask: Task = { id: 0, title: '', description: '' };

  constructor(private taskService: TaskService) {}

  ngOnInit(): void {
    this.loadTasks();
  }

  loadTasks(): void {
    this.tasks$ = this.taskService.getTasks();
  }

  addTask(): void {
    // Check if the newTask has a valid id (greater than 0)
    if (this.newTask.id > 0) {
      this.taskService.updateTask(this.newTask).subscribe(() => {
        this.loadTasks();
        this.newTask = { id: 0, title: '', description: '' };
      });
    } else {
      this.taskService.addTask(this.newTask).subscribe(() => {
        this.loadTasks();
        this.newTask = { id: 0, title: '', description: '' };
      });
    }
  }

  deleteTask(taskId: number): void {
    this.taskService.deleteTask(taskId).subscribe(() => {
      this.loadTasks();
    });
  }

  editTask(task: Task): void {
    this.selectedTask = task;
    this.newTask = { ...task }; // Create a copy to avoid modifying the selected task directly
  }

  updateTask(): void {
    if (this.selectedTask) {
      this.selectedTask.title = this.newTask.title;
      this.selectedTask.description = this.newTask.description;

      this.taskService.updateTask(this.selectedTask).subscribe(() => {
        this.loadTasks();
        this.newTask = { id: 0, title: '', description: '' };
        this.selectedTask = null;
      });
    }
  }
}
