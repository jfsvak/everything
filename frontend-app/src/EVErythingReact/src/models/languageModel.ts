export interface AppLanguage {
    langCode: string;
    text: AppLanguageText;
}

export interface AppLanguageText {
    shared: SharedLanguage;
    dummyPage: DummyPageLanguage
}

export interface SharedLanguage {
    title: string;
}

export interface DummyPageLanguage {
    header :string;
}