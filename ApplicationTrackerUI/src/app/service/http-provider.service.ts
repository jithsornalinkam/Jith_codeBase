import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { WebApiService } from './web-api.service';

//var apiUrl = "https://localhost:44370/";

var apiUrl = "http://localhost:5186";

var httpLink = {
  getAllApplication: apiUrl + "/api/ApplicationTracker/applications",
  deleteApplicationById: apiUrl + "/api/ApplicationTracker/deleteApplicationById",
  getApplicationById: apiUrl + "/api/ApplicationTracker/applications",
  saveApplication: apiUrl + "/api/ApplicationTracker/applications"
}

@Injectable({
  providedIn: 'root'
})
export class HttpProviderService {

  constructor(private webApiService: WebApiService) { }

  public getAllApplication(): Observable<any> {
    return this.webApiService.get(httpLink.getAllApplication);
  }
  public deleteApplicationById(model: any): Observable<any> {
    return this.webApiService.post(httpLink.deleteApplicationById + '?applicationId=' + model, "");
  }
  public getApplicationById(appid: number): Observable<any> {
    return this.webApiService.get(httpLink.getApplicationById + '/'+ appid );
  }
  public saveApplication(model: any): Observable<any> {
    return this.webApiService.post(httpLink.saveApplication, model);
  }  
  
}
