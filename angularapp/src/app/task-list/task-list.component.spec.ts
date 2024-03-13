import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { TaskListComponent } from './task-list.component';
import { ReactiveFormsModule,FormsModule } from '@angular/forms';
import { By } from '@angular/platform-browser';
import { Observable, of } from 'rxjs';
import { TaskService } from '../services/task.service';
import { Task } from '../model/task.model';

describe('TaskListComponent', () => {
  let component: TaskListComponent;
  let fixture: ComponentFixture<TaskListComponent>;
  let taskService: TaskService;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TaskListComponent ],
      imports:[HttpClientTestingModule,ReactiveFormsModule,FormsModule],
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TaskListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  fit('should_create_task_list_component', () => {
    expect((component as any)).toBeTruthy();
  });

  fit('should_contain_Task_List_heading', () => {
    const taskListHeading = fixture.debugElement.query(By.css('h2')).nativeElement.textContent;
    expect(taskListHeading).toContain('Task List');
  });

  fit('should_contain_Add_Task_heading', () => {
    const addTaskHeading = fixture.debugElement.queryAll(By.css('h2'))[1].nativeElement.textContent;
    expect(addTaskHeading).toContain('Add Task');
  });

  fit('should_use_ngFor_to_iterate_over_tasks', () => {
    // Set tasks$ observable with test data
    const testData: Task[] = [
      { id: 1, title: 'Task 1', description: 'Description 1' },
      { id: 2, title: 'Task 2', description: 'Description 2' },
    ];
    (component as any).tasks$ = of(testData);
    fixture.detectChanges(); // Update view to display the tasks
    const taskElements = fixture.debugElement.queryAll(By.css('li'));
    expect((taskElements as any).length).toBe(testData.length);  
    taskElements.forEach((taskElement, index) => {
      const task = testData[index];
      expect((taskElement as any).nativeElement.textContent).toContain(task.title);
      expect((taskElement as any).nativeElement.textContent).toContain(task.description);
    });
  });
  

  fit('should_have_Delete_and_Edit_buttons', () => {
    // Set tasks$ observable with test data
    (component as any).tasks$ = of([
      { id: 1, title: 'Task 1', description: 'Description 1' },
    ]);
    fixture.detectChanges(); // Update view to display the tasks  
    const allButtons = fixture.debugElement.queryAll(By.css('button')).map(button => button.nativeElement.textContent.trim());
    expect(allButtons).toContain('Delete');
    expect(allButtons).toContain('Edit');
  });

  fit('should_have_a_form_with_submit_function_addTask', () => {
    fixture.detectChanges();
    const formElements = fixture.debugElement.queryAll(By.css('form'));
    expect(formElements.length).toBeGreaterThan(0);
    formElements.forEach(formElement => {
      spyOn((component as any), 'addTask');
      formElement.triggerEventHandler('submit', null);
      expect((component as any).addTask).toHaveBeenCalled();
    });
  });
  
  
  fit('should_have_a_submit_button_named_Add_Task', () => {
    fixture.detectChanges();
    const submitButtonElement = fixture.debugElement.query(By.css('button[type="submit"]'));
    expect(submitButtonElement).toBeTruthy();
    expect(submitButtonElement.nativeElement.textContent.trim()).toBe('Add Task');
  });

  fit('should_have_labels_for_Title_and_Description', () => {
    // Trigger change detection to update the view
    fixture.detectChanges();
    // Get all label elements
    const labelElements = fixture.debugElement.queryAll(By.css('label'));  
    // Find label elements with specific text content (ignoring trailing colon)
    const titleLabel = labelElements.find(label => label.nativeElement.textContent.trim().startsWith('Title'));
    const descriptionLabel = labelElements.find(label => label.nativeElement.textContent.trim().startsWith('Description'));  
    // Expect both labels to be defined
    expect(titleLabel).toBeDefined();
    expect(descriptionLabel).toBeDefined();
  });
  

});
