import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { HttpProviderService } from '../service/http-provider.service';

@Component({
  selector: 'app-edit-application',
  templateUrl: './edit-application.component.html',
  styleUrls: ['./edit-application.component.scss']
})
export class EditApplicationComponent implements OnInit {
  editApplicationForm: applicationForm = new applicationForm();

  @ViewChild("applicationForm")
  applicationForm!: NgForm;

  isSubmitted: boolean = false;
  applicationId: any;

  constructor(private toastr: ToastrService, private route: ActivatedRoute, private router: Router,
    private httpProvider: HttpProviderService) { }

    ngOnInit(): void {
      this.applicationId = this.route.snapshot.params['applicationId'];
      this.getApplicationById();
    }

  getApplicationById() {
    this.httpProvider.getApplicationById(this.applicationId).subscribe((data: any) => {
      if (data != null && data.body != null) {
        var resultData = data.body;
        if (resultData) {
          this.editApplicationForm.Id = resultData.id;
          this.editApplicationForm.CompanyName = resultData.firstName;
          this.editApplicationForm.Position = resultData.lastName;
          this.editApplicationForm.Status = resultData.email;
          this.editApplicationForm.DateApplied = resultData.address;
        }
      }
    },
      (error: any) => { });
  }

  EditApplication(isValid: any) {
    this.isSubmitted = true;
    if (isValid) {
      this.httpProvider.saveApplication(this.editApplicationForm).subscribe(async data => {
        if (data != null && data.body != null) {
          var resultData = data.body;
          if (resultData != null && resultData.isSuccess) {
            if (resultData != null && resultData.isSuccess) {
              this.toastr.success(resultData.message);
              setTimeout(() => {
                this.router.navigate(['/Home']);
              }, 500);
            }
          }
        }
      },
        async error => {
          this.toastr.error(error.message);
          setTimeout(() => {
            this.router.navigate(['/Home']);
          }, 500);
        });
    }
  }
}

export class applicationForm {
  Id: number = 0;
  CompanyName: string = "";
  Position: string = "";
  Status: string = "";
  DateApplied: string = "";
}
