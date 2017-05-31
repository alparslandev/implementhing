namespace MyBlog.Features
{
    public class IndexStrings
    {
        public static readonly string DesignHeuristicsTitle = "Daha İyi Bir Tasarım için bazı Tasarım İlkeleri";
        public static readonly string DesignHeuristicsTitleEnglish = "For a Better Design: Design Heuristics";

        public static readonly string CleanCode = "Temiz Kod Hakkında Birkaç Not";
        public static readonly string CleanCodeEnglish = "A few Notes About Clean Code";
        public static readonly string DontDoWorkThatYouDontNeed = "İhtiyacınız olmayan kodları yazmayın.";
        public static readonly string DontDoWorkThatYouDontNeedEnglish = "Don\'t do work that you don\'t need to do.";
        public static readonly string AvoidCreatingUnnecessaryObjects = "Tekrar kullanılabilir Layout sayfaları yapın.";
        public static readonly string AvoidCreatingUnnecessaryObjectsEnglish = "Create a Re-usable Layout";
        public static readonly string PreferStaticOverVirtual = "Obje oluşturmak yerine Static kullanın.";
        public static readonly string PreferStaticOverVirtualEnglish = "Prefer Static Over Virtual";
        public static readonly string UseEnhancedForLoop = "Geliştirilmiş For döngüsü kullanın.";
        public static readonly string UseEnhancedForLoopEnglish = "Use Enhanced For Loop";
        public static readonly string UseNativeMethodsCarefully = "Native(Yerel) methodları kullanmaya özen gösterin.";
        public static readonly string UseNativeMethodsCarefullyEnglish = "Use Native Methods Carefully";




        public static readonly string VariablesTitle = "Nesne Değişkenleri vs Yerel Değişkenler";
        public static readonly string VariablesTitleEnglish = "Instance Variables vs Local Variables";
        public static readonly string VariablesContent = "Nesne değişkenleri ve objeleri Heap yapısı içerisinde kaydedilir. Bunun obje durumunun yönetildiği yer olduğunu ve memory leak e yol açabileceğini unutmayın.\n\n\nYerel değişkenler ve methodlar ise Stack yapısı içerisinde bulunur. Eğer go isminde, gone() methodunu çağıran, bir yönetim methodu varsa aşağıdan yukarıya gone() < go() < main() sırasıyla işlenirler. gone() işlenip işi bittiğinde Stack'ten kaldırılır. gone() içeriisnde tanımlanan tüm değişkenler de Stack'ten silinir.\n\n\nÖzet olarak: Performans istiyorsanız Global değişkenler kullanmayın. Mümkün olduğunca yerel değişkenler kullanın.";
        public static readonly string VariablesContentEnglish = "Instance variables and Objects lie on Heap. Remember this is where the state is maintained and when you get memory leaks. \n\n\nLocal variables and methods lie on the Stack. So if we have a main method which calls the go() method which calls the gone() method then the stack from top to bottom would consist of gone() < go() < main() as soon as gone() has been processed it would be removed from the stack. Any corresponding local variables which are used in gone() would also be removed from the stack.\n\n\nTo summarize: Do not use Global variables for performans. Use Local variables instead.";
        
        public static readonly string VisibilityOfSystemStatusTitle = "Sistem Durumunun Görünürlüğü";
        public static readonly string VisibilityOfSystemStatusTitleEnglish = "Visibility of System Status";
        public static readonly string VisibilityOfSystemStatusContent = "Sistem kullanıcıyı daima neler olduğuna dair bilgilendirmeli ve gerektiği zaman geribildirim yapmalı.";
        public static readonly string VisibilityOfSystemStatusContentEnglish = "The system should always keep users informed about what is going on, through appropriate feedback within reasonable time.";

        public static readonly string UserControlandFreedomTitle = "Kullanıcı Kontrolü ve Özgürlüğü";
        public static readonly string UserControlandFreedomTitleEnglish = "User Control and Freedom";
        public static readonly string UserControlandFreedomContent = "Kullanıcılar sıklıkla sistemi yanlış kullanırlar ve kendilerini istemedikleri bir duruma sokmadan kurtarabilecek bir tür \"Acil Çıkış\" ihtiyaçları olur. Geri ve ileri gidebilmeyi desteklemek en iyisidir";
        public static readonly string UserControlandFreedomContentEnglish = "Users often choose system functions by mistake and will need a clearly marked \"emergency exit\" to leave the unwanted state without having to go through an extended dialogue. Support undo and redo.";

        public static readonly string RecognitionRatherThanRecallTitle = "Hatırlama Yerine Tanıma";
        public static readonly string RecognitionRatherThanRecallTitleEnglish = "Recognition rather than recall";
        public static readonly string RecognitionRatherThanRecallContent = "Nesneleri, eylemleri ve seçenekleri görünür hale getirerek kullancının bellek yükünü en aza indirin. Kullanıcı diyalogun bir kısmındaki veriyi anlamak için başka bir yerdeki veriyi ezberlemek zorunda olmamalı. Sistemin kullanımı için gerekli açıklamalar açık ve anlaşılır olmalı.";
        public static readonly string RecognitionRatherThanRecallContentEnglish = "Minimize the user\'s memory load by making objects, actions, and options visible. The user should not have to remember information from one part of the dialogue to another. Instructions for use of the system should be visible or easily retrievable whenever appropriate.";

        public static readonly string ErrorPreventionTitle = "Hata Sunumu";
        public static readonly string ErrorPreventionTitleEnglish = "Error prevention";
        public static readonly string ErrorPreventionContent = "İyi hata mesajlarından daha iyisi, bir sorunun başta oluşmasını önleyen dikkatli bir tasarımdır. Hata eğilimli koşulları ortadan kaldırın veya kontrol edin ve eylemi gerçekleştirmeden önce kullanıcılara bir onaylama seçeneği sunun";
        public static readonly string ErrorPreventionContentEnglish = "Even better than good error messages is a careful design which prevents a problem from occurring in the first place. Either eliminate error-prone conditions or check for them and present users with a confirmation option before they commit to the action.";

        public static readonly string MatchBetweenSystemAndtheRealWorldTitle = "Sistemin Gerçek Dünya ile Olan Uyumu";
        public static readonly string MatchBetweenSystemAndtheRealWorldTitleEnglish = "Match between system and the real world";
        public static readonly string MatchBetweenSystemAndtheRealWorldContent = "Sistem Kullanıcının dilini konuşmalıdır. Sistemin kullandığı dil, sistem odaklı değil, kullandığı kelimelerle ve ifadelerle kullanıcı odaklı olmalıdır. Gerçek dünyada kullanılan düzen bilginin doğal ve mantıksal görünmesini sağlar.";
        public static readonly string MatchBetweenSystemAndtheRealWorldContentEnglish = "The system should speak the users\' language, with words, phrases and concepts familiar to the user, rather than system-oriented terms. Follow real-world conventions, making information appear in a natural and logical order.";
        
        public static readonly string SeparationTitle = "İlgilerin Ayrılığı";
        public static readonly string SeparationTitleEnglish = "Separation Of Concerns";
        public static readonly string SeparationContent = "Kodu her farklı katman veya işleyiş olarak ayrı tutar. İnterface\'i değiştirmek iş mantığını değiştirmeyi gerektirmemelidir veya tam tersi. Model-View-Controller (MVC) tasarım kalıbı bunun yazılım yönetimi bakımından en güzel örneğidir.";
        public static readonly string SeparationContentEnglish = "Keeps the code for each of different concerns separate. Changing interface should not require changing business logic code, and vice versa. Model-View-Controller (MVC) design pattern is an excellent example of separating concerns for better software maintainability.";

        public static readonly string VerificationVsValidationTitle = "Doğrulama vs Onaylama";
        public static readonly string VerificationVsValidationTitleEnglish = "Verification vs Validation";
        public static readonly string VerificationVsValidationContent = "Doğrulama(Verification) sistemin hatasız, iyi organize edilip edilmediği gibi özellikleri ile ilgilenirken, Onaylama(Validation) sistemin müşterinin ihtiyaçlarını karşılayıp karşılamadığı ile ilgilenir. Doğrulama, yazılımın kalitesini belirler ancak kullanışlı olup olmadığı ile ilgilenmez.";
        public static readonly string VerificationVsValidationContentEnglish = "Validation concernes with checking that the system will meet the customer’s actual needs, while verification is concerned with whether the system is well-engineered, error-free, and so on. Verification will help to determine whether the software is of high quality, but it will not ensure that the system is useful.";

        public static readonly string DesignPatternsTitle = "Tasarım Kalıpları";
        public static readonly string DesignPatternsTitleEnglish = "Design Patterns";
        public static readonly string DesignPatternsContent = "Bir tasarım kalıbı, yazılım dizaynında ortak olarak ortaya çıkan problemlere genel olarak tekrar edilebilir bir çözümdür. Bir tasarım kalıbı bitmiş bir tasarım olmadığı için direkt olarak koda dönüştürülebilir. Problemin nasıl çözüleceğine bir taslak gösterir ki bu da farklı durumlara uyabilmesini sağlar.";
        public static readonly string DesignPatternsContentEnglish = "A design pattern is a general repeatable solution to a commonly occurring problem in software design. A design pattern isn\'t a finished design that can be transformed directly into code. It is a description or template for how to solve a problem that can be used in many different situations.";

    }
}