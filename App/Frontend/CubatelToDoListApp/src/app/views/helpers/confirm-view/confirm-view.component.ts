import {
  Component,
  EventEmitter,
  Input,
  OnInit,
  Output,
  ViewChild,
} from '@angular/core';

declare var window: any;

@Component({
  selector: 'app-confirm-view',
  templateUrl: './confirm-view.component.html',
  styleUrls: ['./confirm-view.component.scss'],
})
export class ConfirmViewComponent implements OnInit {
  @Input() itemToConfirm: any = null;
  @Input() btnTitle: string = '';
  @Input() styleTemplate: string = 'warning';
  @Input() confirmText: string = '';

  @Output() confirmEvent = new EventEmitter<any>();

  public headerTemplate = 'bg-primary';
  public btnTemplate = 'btn btn-primary';

  formModal: any;

  constructor() {}
  ngOnInit(): void {
    this.setTemplates();
    this.formModal = new window.bootstrap.Modal(
      document.getElementById('confirmModal')
    );
  }

  setTemplates() {
    switch (this.styleTemplate) {
      case 'danger':
        this.btnTemplate = 'btn btn-danger';
        this.headerTemplate = 'bg-danger text-white';
        break;
      case 'warning':
        this.btnTemplate = 'btn btn-warning';
        this.headerTemplate = 'bg-warning text-white';
        break;
    }
  }

  OnConfirm(confirm: boolean) {
    this.formModal.hide();
    if (confirm) {
      this.confirmEvent.emit(this.itemToConfirm);
    } else {
      this.confirmEvent.emit(null);
    }
  }
}
