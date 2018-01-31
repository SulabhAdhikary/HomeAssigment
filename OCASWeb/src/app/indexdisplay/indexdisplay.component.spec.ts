import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { IndexdisplayComponent } from './indexdisplay.component';

describe('IndexdisplayComponent', () => {
  let component: IndexdisplayComponent;
  let fixture: ComponentFixture<IndexdisplayComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ IndexdisplayComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(IndexdisplayComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
