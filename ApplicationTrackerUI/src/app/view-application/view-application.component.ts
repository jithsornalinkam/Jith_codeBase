import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpProviderService } from '../service/http-provider.service';
import { WebApiService } from '../service/web-api.service';

@Component({
  selector: 'app-view-application',
  templateUrl: './view-application.component.html',
  styleUrls: ['./view-application.component.scss']
})
export class ViewApplicationComponent implements OnInit {

  applicationId: any;
  applicationDetails : any= [];
   
  constructor(public webApiService: WebApiService, private route: ActivatedRoute, private httpProvider : HttpProviderService) { }
  
  ngOnInit(): void {
    this.applicationId = this.route.snapshot.params['applicationId'];   
    this.getApplicationById();
  }

  getApplicationById() {       
    this.httpProvider.getApplicationById(this.applicationId).subscribe((data : any) => {      
      if (data != null && data.body != null) {
        var resultData = data.body;
        if (resultData) {
          this.applicationDetails = resultData;
        }
      }
    },
    (error :any)=> { }); 
  }

}
