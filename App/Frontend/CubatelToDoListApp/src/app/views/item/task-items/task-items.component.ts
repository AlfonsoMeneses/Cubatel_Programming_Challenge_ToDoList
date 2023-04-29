import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ItemDto } from 'src/app/models/item.model';
import { TaskDto } from 'src/app/models/task.model';
import { TaskService } from 'src/app/services/task/task.service';
import { ItemService } from 'src/app/services/item/item.service';

declare var window: any;

@Component({
  selector: 'app-task-items',
  templateUrl: './task-items.component.html',
  styleUrls: ['./task-items.component.scss'],
})
export class TaskItemsComponent implements OnInit {
  //Date
  public task: any;
  public taskId: any;
  public taskName: string='';

  public selectedItem: ItemDto = new ItemDto(-1, -1, '', '', 0);

  //Models
  confirmRemoveModel: any;
  createModal: any;
  completeModal: any;
  errorModal: any;

  //Validaciones
  public isWaiting: boolean = false;

  //Errors
  public hasError: boolean = false;
  public errorMessage: string = '';

  constructor(
    private _taskService: TaskService,
    private _itemService: ItemService,
    private _activateRoute: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.setModals();
    this.getTaskId();
  }

  //Modals
  setModals() {
    this.confirmRemoveModel = new window.bootstrap.Modal(
      document.getElementById('removeModal')
    );

    this.createModal = new window.bootstrap.Modal(
      document.getElementById('createOrEditModal')
    );

    this.completeModal = new window.bootstrap.Modal(
      document.getElementById('completeModal')
    );

    this.errorModal = new window.bootstrap.Modal(
      document.getElementById("errorModal")
    );

  }

  getTaskId() {
    this._activateRoute.params.subscribe((params) => {
      let id = params['id'];

      if (id) {
        this.taskId = id;
        this.getTaskInfo();
      }
    });
  }

  getTaskInfo() {
    this.isWaiting = true;

    this._taskService.getTaskItems(this.taskId).subscribe(
      (response) => {
        this.task = response;
        this.taskName = this.task.name;
        this.isWaiting = false;
      },
      (error) => {
        this.isWaiting = false;
        this.OnError(error);
      }
    );
  }

  refresh() {
    this.getTaskInfo();
  }

  //Templates
  isItemComplete(item: ItemDto): boolean {
    if (item.isCompleted == 1) {
      return true;
    }

    return false;
  }
  //Create Or Edit
  OnViewNewTaskModal() {
    this.selectedItem = new ItemDto(-1, -1, '', '', 0);
    this.createModal.show();
  }

  OnCrearOrEdit(status: any) {
    this.createModal.hide();
    if (status) {
      this.getTaskInfo();
    }
  }

  //Edit Task
  OnShowEditItemModal(itemToEdit: ItemDto) {
    this.selectedItem.idItem = itemToEdit.idItem;
    this.selectedItem.name = itemToEdit.name;
    this.selectedItem.description = itemToEdit.description;

    this.createModal.show();
  }


  //Remove
  OnConfirmRemove(item: ItemDto) {
    this.selectedItem = item;
    this.confirmRemoveModel.show();
  }

  OnRemoveItem() {
    this.confirmRemoveModel.hide();

    this.isWaiting = true;

    this._itemService.remoteItem(this.selectedItem.idItem).subscribe(
      (response) => {
        this.isWaiting = false;
        this.getTaskInfo();
      },
      (error) => {
        this.isWaiting = false;
        this.OnError(error);
      }
    );
  }

  //Complete Item
  OnCompleteConfirmItem(item: ItemDto) {
    this.selectedItem = item;
    this.completeModal.show();
  }

  OnCompleteItem() {
    this.completeModal.hide();

    this._itemService.completeItem(this.selectedItem.idItem).subscribe(
      (response) => {
        this.isWaiting = false;
        this.getTaskInfo();
      },
      (error) => {
        this.isWaiting = false;
        this.OnError(error);
      }
    );
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
