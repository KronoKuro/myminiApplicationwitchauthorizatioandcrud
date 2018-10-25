import { Component, OnInit, Input } from '@angular/core';
import { NewsService } from '../news.service';
import { Observable } from 'rxjs';
import { New } from '../models/new.model';
import { MatDialog } from '@angular/material';
import { NewsAddComponent } from './news-add/news-add.component';
import { NewsEditComponent } from './news-edit/news-edit.component';
import { Router } from '@angular/router';
import { RoleGuard } from '../role.guard';

@Component({
  selector: 'app-news',
  templateUrl: './news.component.html',
  styleUrls: ['./news.component.css']
})
export class NewsComponent implements OnInit {
  isadmin: boolean = false;
  constructor(private newsService: NewsService, private dialog: MatDialog, private router: Router, private role: RoleGuard) { };
   
  news: New[]; 
  displayedColumns: string[] = ['Id', 'Title', 'Text', 'DatePost', 'actions'];
  
  ngOnInit() {
    this.isadmin = this.role.IsAdmin();
    console.log(this.isadmin);
    this.getNews();
  }

  getNews() {
    this.newsService.getNews().subscribe(resp => {
      this.news = resp;
    });
  }

  addNews(news: New) {
    const dialogRef = this.dialog.open(NewsAddComponent, {
      data: { news: news }
    });
    dialogRef.afterClosed().subscribe(res => {
      this.getNews();
    })
  }

  

  deleteNews(id: number) {
    this.newsService.deleteNews(id).subscribe(resp => {
      alert('News deleted');
      this.getNews();
    });
  }

  editNews(news: New) {
    const dialogRef = this.dialog.open(NewsEditComponent, {
      data: { news }
    });
    dialogRef.afterClosed().subscribe(res => {
      this.getNews();
    })
  }

  logout() {
    localStorage.clear();
    this.router.navigate(['login']);
  }

}
