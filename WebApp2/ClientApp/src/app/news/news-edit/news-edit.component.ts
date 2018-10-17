import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { New } from '../../models/new.model';
import { NewsService } from '../../news.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-news-edit',
  templateUrl: './news-edit.component.html',
  styleUrls: ['./news-edit.component.css']
})
export class NewsEditComponent implements OnInit {

  newsForm: FormGroup;

  constructor(public dialogRef: MatDialogRef<NewsEditComponent>, 
    @Inject(MAT_DIALOG_DATA) public data: any, 
    private newsService: NewsService) {
      this.newsForm = new FormGroup({
        'Title': new FormControl(data.news.title, Validators.required),
        'Text': new FormControl(data.news.text, Validators.required),
        'Id': new FormControl(data.news.id),
        'DatePost': new FormControl(data.news.datePost)
      });
    }

  ngOnInit() {

  }

  getErrorMessage() {
     console.log('Error');
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

  stopEdit(): void {
    this.newsService.updateNews(this.newsForm.getRawValue());
  }


}
