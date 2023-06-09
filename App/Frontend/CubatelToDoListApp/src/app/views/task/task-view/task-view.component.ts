import { Component, OnInit } from '@angular/core';
import { TaskDto } from 'src/app/models/task.model';
import { TaskService } from 'src/app/services/task/task.service';

declare var window:any;

@Component({
  selector: 'app-task-view',
  templateUrl: './task-view.component.html',
  styleUrls: ['./task-view.component.scss'],
})
export class TaskViewComponent implements OnInit {
  //Datos
  public tasks: Array<any> = [];
  public selectedTask:TaskDto = new TaskDto(-1,'','');

  //Validaciones
  public isWaiting: boolean = false;

  //Errors
  public hasError: boolean = false;
  public errorMessage: string = '';

  //Models
  confirmDeleteModel:any;
  createModal:any;
  errorModal:any;

  constructor(private _taskService: TaskService) {}

  ngOnInit(): void {
    this.setModals();
    this.getTask();
  }

  setModals(){
    this.confirmDeleteModel = new window.bootstrap.Modal(
      document.getElementById("exampleModal")
    );

    this.createModal = new window.bootstrap.Modal(
      document.getElementById("createOrEditModal")
    );

    this.errorModal = new window.bootstrap.Modal(
      document.getElementById("errorModal")
    );
  }

  getTask() {
    this.isWaiting = true;
    this._taskService.getTask().subscribe(
      (response) => {
        this.tasks = response;
        this.isWaiting = false;
      },
      (exception) => {
        this.isWaiting = false;
        this.OnError(exception);
      }
    );
  }



  //New Task
  OnViewNewTaskModal(){
    this.selectedTask =  new TaskDto(-1,'','');
    this.createModal.show();
  }

  confirmCreateTask(status:boolean){
    this.createModal.hide();
    if (status) {
      this.getTask();
    }
  }

  //Edit Task
  OnShowEditTaskModal(taskToEdit:TaskDto){
    this.selectedTask.idTask  = taskToEdit.idTask;
    this.selectedTask.name = taskToEdit.name;
    this.selectedTask.description = taskToEdit.description;

    this.createModal.show();
  }

  //Delete Task
  OnConfirmDelete(task: any) {
    this.selectedTask = task;
    this.confirmDeleteModel.show();
  }

  OnDeleteTask() {

      this.confirmDeleteModel.hide();
      this.isWaiting = true;

      this._taskService.delete(this.selectedTask.idTask).subscribe(
        (response) => {
          this.isWaiting = false;
          this.getTask();
        },
        (exception) => {
          this.isWaiting = false;
          this.OnError(exception);
        }
      );

  }

  refresh() {
    this.getTask();
  }

  //Manejo Errores
  OnError(exception: any) {
    let status = exception.status;
    switch (status) {
      case 400:
        this.errorMessage = exception.error.error;
        break;

      default:
        this.errorMessage = 'Internal error, try later';
        break;
    }

    this.hasError = true;

    this.errorModal.show();
  }
}
