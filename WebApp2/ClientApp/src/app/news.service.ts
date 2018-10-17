import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { New } from './models/new.model';

@Injectable()
export class NewsService {

  constructor(private http: HttpClient) { }

  private url: string = 'api/news';

  getNews()
  {
    return this.http.get<New[]>(this.url);
  }

  addNews(news: New)
  {
    console.log(news);
    return this.http.post<New>(this.url, news);
  }

  deleteNews(id: number)
  {
    return this.http.delete(this.url + '/' + id);
  }

  updateNews(news: New)
  {
    console.log(news);
    this.http.put(this.url,  news).subscribe(resp => {
         console.log(this.url + '/'+ news.Id, news);
    }, error => {
      console.log(error);
    })
  }

}
