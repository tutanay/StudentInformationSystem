import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { OgrSayfaComponent } from './ogr-sayfa.component';

describe('OgrSayfaComponent', () => {
  let component: OgrSayfaComponent;
  let fixture: ComponentFixture<OgrSayfaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ OgrSayfaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OgrSayfaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
