import configs from '../configs';
import english from '../assets/languages/en-lang';
import swedish from '../assets/languages/sw-lang';
import danish from '../assets/languages/dk-lang';
import { AppLanguageText } from '../models/languageModel';

export function getLanguage(): AppLanguageText {
    let code: string = configs.lang ? configs.lang : 'sw';
    switch (code) {
        case 'en': return english.text;
        case 'sw': return swedish.text;
        case 'dk': return danish.text;
        default: return english.text;
    }
}

export function changeLanguage(code: string, callback): void {
    let langCode: string = code ? code : configs.lang;
    let newLang: AppLanguageText;
    switch (langCode) {
        case 'en':
            configs.lang = 'en';
            newLang = english.text;
            break;
        case 'sw':
            configs.lang = 'sw';
            newLang = swedish.text;
            break;
        case 'dk':
            configs.lang = 'dk';
            newLang = danish.text;
            break;
        default:
            configs.lang = 'en';
            newLang = english.text;
    }
    callback(newLang);
}