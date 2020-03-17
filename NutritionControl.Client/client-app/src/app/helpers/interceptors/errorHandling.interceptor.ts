import { Injectable } from '@angular/core'
import { HttpInterceptor, HttpRequest, HttpEvent, HttpHandler, HttpResponse, HttpErrorResponse } from '@angular/common/http'
import { Observable } from 'rxjs'
import { tap } from 'rxjs/operators'
import { ApiResponse } from 'src/app/models/apiResponse'
import { AlertifyService } from 'src/app/services/layout/alertify.service'


@Injectable()
export class ErrorHandlingInterceptor implements HttpInterceptor {
  constructor(private alertifyService: AlertifyService) { }

  intercept(
    req: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    return next.handle(req).pipe(
      tap(
        event => {
          if (event instanceof HttpResponse) {
            let res: ApiResponse = event.body;
            if (!res.isSuccessful) {
              this.alertifyService.error(res.message);
            }
          }
        },
        err => {
          if (err instanceof HttpErrorResponse) {
            if (err.status == 401) {
              this.alertifyService.error("You need to authorize");
            }
          }
        }
      )
    )
  }
}