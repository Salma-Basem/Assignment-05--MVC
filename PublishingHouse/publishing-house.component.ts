import { Component, HostBinding } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { LanguageService } from 'src/app/Services/language.service';
import { MetaService } from 'src/app/Services/meta.service';

@Component({
  selector: 'app-publishing-house',
  templateUrl: './publishing-house.component.html',
  styleUrls: ['./publishing-house.component.css']
})
export class PublishingHouseComponent {
  language: string = 'en';
  isArabic: boolean = false;
  @HostBinding('attr.dir') get dir() {
    return this.language === 'ar' ? 'rtl' : 'ltr';
  }

  constructor(private languageService: LanguageService,
    private metaService: MetaService,private title: Title) { }

  ngOnInit() {
    // Subscribe to language changes
    this.languageService.getLanguage().subscribe(language => {
      this.language = language;
      this.isArabic = this.language === 'ar';

    });
    this.metaService.updateMetaTags(
     "Publishing House Project - دار غايا للنشر" ,
     "website",
     "https://www.ghayaeg.com/Projects/PublishingHouse",
     "https://www.ghayaeg.com/assets/Images/GhayaLogo.png",
      "اقرأ كتابك إن أردت مكانةً، فالمجد يحني الرأس للقراء. ",
      "Publishing House Project"
   
    );
  }
    // Switching Languages 
  changeLanguage(newLanguage: string) {
    this.languageService.setLanguage(newLanguage);
  }
  //Gmail Method 
  goToGmail(): void {
    const toEmailAddress = 'publishing@ghayaeg.com';
    const subject = '';
    const body = '';

    // Construct mailto URL with subject and body
    const mailtoUrl = `mailto:${toEmailAddress}?subject=${encodeURIComponent(subject)}&body=${encodeURIComponent(body)}`;

    // Open the mailto URL
    window.location.href = mailtoUrl;
  }
}