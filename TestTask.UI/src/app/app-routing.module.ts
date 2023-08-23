import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddOrderComponent } from './components/add-order/add-order.component';
import { MainAppComponent } from './components/main-app/main.component';

const routes: Routes = [
  { path:'', component:MainAppComponent},
  { path:'newOrder', component:AddOrderComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
