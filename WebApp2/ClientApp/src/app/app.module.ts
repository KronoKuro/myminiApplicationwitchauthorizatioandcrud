import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { LoginFormComponent } from './login-form/login-form.component';

import { AuthService } from './auth.service';
import { NewsService } from './news.service';
import { AuthInterceptor } from './auth.interceptor';
import { NewsComponent } from './news/news.component';
import { MaterialModule } from './material.module.module';
import { NewsAddComponent } from './news/news-add/news-add.component';
import { NewsEditComponent } from './news/news-edit/news-edit.component';
import { AuthGuard } from './login-form/auth.guard';
import { RegisterFormComponent } from './register-form/register-form.component';
import { HomeComponent } from './home/home.component';
import { MovieService } from './movie.service';
import { CreateMovieComponent } from './home/create-movie/movie-create.component';
import { MovieDetailComponent } from './home/detail-movie/movie-detail.component';
import { MovieEditComponent } from './home/edit-movie/edit-movie.component';
import { NavigationComponent } from './navigation/navigation.component';
import { RoleGuard } from './role.guard';
import { GenresServices } from './genres.services';
import { UserComponent } from './user/user.component';
import { UserServices } from './user.services';
import { GenreComponent } from './genre/genre.component';


const Routes = [
  {path: '', redirectTo: '/home', pathMatch: 'full'},
  {path: 'login', component: LoginFormComponent},
  {path: 'home', component: HomeComponent},
  {path: 'register', component: RegisterFormComponent},
  { path: 'news', component: NewsComponent },
  { path: 'create-movie', component: CreateMovieComponent, canActivate: [RoleGuard], data: {expectedRole:'Admin'}},
  { path: 'detail-movie/:id', component: MovieDetailComponent },
  { path: 'edit-movie/:id', component: MovieEditComponent, canActivate: [RoleGuard], data: { expectedRole: 'Admin' } },
  { path: 'genres/:id', component: GenreComponent },
  // { path: '**', component: NotFoundComponent }
];

@NgModule({
  declarations: [
    AppComponent,
    NavigationComponent,
    LoginFormComponent,
    NewsComponent,
    HomeComponent,
    CreateMovieComponent,
    NewsAddComponent,
    NewsEditComponent,
    RegisterFormComponent,
    MovieDetailComponent,
    MovieEditComponent,
    UserComponent,
    GenreComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    BrowserAnimationsModule,
    MaterialModule,
    FormsModule,
    RouterModule.forRoot(Routes),
    ReactiveFormsModule
  ],
  entryComponents: [
    NewsAddComponent,
    NewsEditComponent,
  ],
  providers: [AuthService, NewsService, MovieService, GenresServices, UserServices, AuthGuard, RoleGuard,
              {
                provide: HTTP_INTERCEPTORS ,
                useClass: AuthInterceptor,
                multi: true
              }],
  bootstrap: [AppComponent]
})
export class AppModule { }
