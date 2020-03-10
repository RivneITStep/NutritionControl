import { Injectable } from '@angular/core';
import alertify from 'node_modules/alertifyjs';

@Injectable({
  providedIn: 'root'
})
export class AlertifyService {

  constructor() {
    alertify.defaults.transition = "slide";
    alertify.defaults.theme.ok = "btn btn-primary";
    alertify.defaults.theme.cancel = "btn btn-danger";
    alertify.defaults.theme.input = "form-control";
  }

  confirm(title: string, message: string, okCallback: () => any, cancelCallback: () => any = null) {
    alertify.confirm(title, message, function(e) {
      if (e) {
        okCallback();
      }
    }, function(e) {
      if(e && cancelCallback) {
        cancelCallback();
      }
    });
  }

  success(message: string): void {
    alertify.success(message);
  }
  
  error(message: string) {
    alertify.error(message);
  }
  
  warning(message: string) {
    alertify.warning(message);
  }
  
  message(message: string) {
    alertify.message(message);
  }
}