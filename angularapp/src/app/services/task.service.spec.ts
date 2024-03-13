import { TestBed, inject } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { TaskService } from './task.service';
import { Task } from '../model/task.model';

describe('TaskService', () => {
  let service: TaskService;
  let httpMock: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [TaskService]
    });
    service = TestBed.inject(TaskService);
    httpMock = TestBed.inject(HttpTestingController);
  });

  afterEach(() => {
    httpMock.verify();
  });

  fit('should_create_task_service', () => {
    expect((service as any)).toBeTruthy();
  });

  fit('should_retrieve_tasks_from_the_API_via_GET', () => {
    const dummyTasks: Task[] = [
      { id: 1, title: 'Task 1', description: 'Description 1' },
      { id: 2, title: 'Task 2', description: 'Description 2' }
    ];
    (service as any).getTasks().subscribe(tasks => {
      expect(tasks).toEqual(dummyTasks);
    });
    const req = httpMock.expectOne((service as any).apiUrl);
    expect(req.request.method).toBe('GET');
    req.flush(dummyTasks);
  });

  fit('should_add_a_new_task_via_POST', () => {
    const newTask: Task = { id: 3, title: 'Task 3', description: 'Description 3' };
    (service as any).addTask(newTask).subscribe(task => {
      expect(task).toEqual(newTask);
    });
    const req = httpMock.expectOne((service as any).apiUrl);
    expect(req.request.method).toBe('POST');
    req.flush(newTask);
  });

  fit('should_update_an_existing_task_via_PUT', () => {
    const updatedTask: Task = { id: 1, title: 'Updated Task', description: 'Updated Description' };
    (service as any).updateTask(updatedTask).subscribe(task => {
      expect(task).toEqual(updatedTask);
    });
    const req = httpMock.expectOne(`${((service as any)).apiUrl}/${updatedTask.id}`);
    expect(req.request.method).toBe('PUT');
    req.flush(updatedTask);
  });

  fit('should_delete_a_task_via_DELETE', () => {
    const taskId = 1;
    (service as any).deleteTask(taskId).subscribe(() => {
      // No return value for DELETE requests
    });
    const req = httpMock.expectOne(`${(service as any).apiUrl}/${taskId}`);
    expect(req.request.method).toBe('DELETE');
    req.flush(null);
  });

});
