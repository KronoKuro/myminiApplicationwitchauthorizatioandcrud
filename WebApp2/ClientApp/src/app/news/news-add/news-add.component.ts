import { Component, OnInit, Inject, Output } from '@angular/core';
import { NewsService } from '../../news.service';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { New } from '../../models/new.model';
import { FormControl, Validators, FormGroup } from '@angular/forms';
import { EventEmitter } from '@angular/core';

@Component({
  selector: 'app-news-add',
  templateUrl: './news-add.component.html',
  styleUrls: ['./news-add.component.css']
})
export class NewsAddComponent implements OnInit {

  constructor(private newsService: NewsService,
     private dialogRef: MatDialogRef<NewsAddComponent>,
     @Inject(MAT_DIALOG_DATA) public news: New) {
       this.newsForm = new FormGroup({
         'Title': new FormControl('', [Validators.required, Validators.maxLength(250)]),
         'Text': new FormControl('', Validators.required),
       })
     }

  ngOnInit() {
  }
  newsItem: New;

  newsForm: FormGroup;

  formControl = new FormControl('', [
    Validators.required
  ]);

  onNoClick() {
    this.dialogRef.close();
  }
  public confirmAdd() {
    let date = new Date()
    this.newsForm.addControl('DatePost', new FormControl(date));
    this.newsService.addNews(this.newsForm.getRawValue()).subscribe(resp => {
      
    })
    /* this.newsService.addNews(this.news).subscribe(news => {
      this.newsItem = this.news;
    }); */
}

getErrorMessage() {
  return this.formControl.hasError('required') ? 'Required field' :
    this.formControl.hasError('email') ? 'Not a valid email' :
      '';
}

}
