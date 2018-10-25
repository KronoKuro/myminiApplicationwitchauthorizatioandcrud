import { Component, OnInit } from '@angular/core';
import { NewsService } from '../news.service';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';
import { GenresServices } from '../genres.services';
import { Genre } from '../models/genre.model';

@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.css']
})
export class NavigationComponent {

  genres: Genre[];
  isExpanded = false;

  constructor(private router: Router, private genreServie: GenresServices) { };

  ngOnInit() {
    this.getGenres();
  }

  getGenres() {
    this.genreServie.getGenres().subscribe(res => {
      this.genres = res;
    });
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  logout() {
    localStorage.clear();
    this.router.navigate(['login']);
  }

}
