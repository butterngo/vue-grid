import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

import { AppComponent } from './app.component';
import { ConfirmDirective } from './shared/directives/confirm-directive/confirm.directive';
import { ProperCasePipe } from './shared/pipes/propercase.pipe';
import { DynamicGridComponent } from './dynamic-grid/dynamic-grid.component';

@NgModule({
  declarations: [
    AppComponent,
    ConfirmDirective,
    ProperCasePipe,
    DynamicGridComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
