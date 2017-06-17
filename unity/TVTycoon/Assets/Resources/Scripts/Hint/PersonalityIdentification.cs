using System;

public class PersonalityIdentification
{
    public string shortDescription;
    public string description;

    public static PersonalityIdentification architect,
        logic,
        commander,
        innovator,
        attorney,
        mediator,
        protagonist,
        activist,
        logistic,
        defender,
        executive,
        cosul,
        virtuous,
        adventurer,
        entrepreneur,
        entertainer;

//    public int bonus;
    public PersonalityIdentification getPersonalityIdentification(PersonalityTrace trace)
    {
        switch (trace)
        {
            case PersonalityTrace.ARCHITECT:
                if (architect == null)
                {
                    architect = new PersonalityIdentification();
                    architect.shortDescription = "Pensadores criativos e estratégicos, com um plano para tudo.";
                }
                return architect;
            case PersonalityTrace.LOGIC:
                if (logic == null)
                {
                    logic = new PersonalityIdentification();
                    logic.shortDescription = "Criadores inovadores com uma sede insaciável por conhecimento.";
                }
                return logic;
            case PersonalityTrace.COMMANDER:
                if (commander == null)
                {
                    commander = new PersonalityIdentification();
                    commander.shortDescription =
                        "Líderes ousados, criativos e enérgicos, sempre dando um jeito em tudo.";
                }
                return commander;
            case PersonalityTrace.INNOVATOR:
                if (innovator == null)
                {
                    innovator = new PersonalityIdentification();
                    innovator.shortDescription =
                        "Pensadores espertos e curiosos que não resistem um desafio intelectual.";
                }
                return innovator;
            case PersonalityTrace.ATTORNEY:
                if (attorney == null)
                {
                    attorney = new PersonalityIdentification();
                    attorney.shortDescription =
                        "Idealistas quietos e místicos, porém muito inspiradores e incansáveis.";
                }
                return attorney;
            case PersonalityTrace.MEDIATOR:
                if (mediator == null)
                {
                    mediator = new PersonalityIdentification();
                    mediator.shortDescription =
                        "Pessoas poéticas, bondosas e altruístas, sempre prontas para ajudar uma boa causa.";
                }
                return mediator;
            case PersonalityTrace.PROTAGONIST:
                if (protagonist == null)
                {
                    protagonist = new PersonalityIdentification();
                    protagonist.shortDescription =
                        "Líderes inspiradores e carismáticos, que conseguem hipnotizar sua audiência.";
                }
                return protagonist;
            case PersonalityTrace.ACTIVIST:
                if (activist == null)
                {
                    activist = new PersonalityIdentification();
                    activist.shortDescription =
                        "Espíritos livres, criativos, sociáveis e entusiasmáticos, sempre encontrando uma " +
                        "razão para sorrir.";
                }
                return activist;
            case PersonalityTrace.LOGISTIC:
                if (logistic == null)
                {
                    logistic = new PersonalityIdentification();
                    logistic.shortDescription = "Indivíduos práticos e extremamente confiáveis.";
                }
                return logistic;
            case PersonalityTrace.DEFENDER:
                if (defender == null)
                {
                    defender = new PersonalityIdentification();
                    defender.shortDescription =
                        "Protetores dedicados e acolhedores, estão sempre prontos para defender seus amados.";
                }
                return defender;
            case PersonalityTrace.EXECUTIVE:
                if (executive == null)
                {
                    executive = new PersonalityIdentification();
                    executive.shortDescription =
                        "Administradores excelentes, inigualáveis em gerenciar coisas - ou pessoas.";
                }
                return executive;
            case PersonalityTrace.COSUL:
                if (cosul == null)
                {
                    cosul = new PersonalityIdentification();
                    cosul.shortDescription =
                        "Pessoas extraordinariamente atenciosas, sociais e populares, sempre prontas para ajudar.";
                }
                return cosul;
            case PersonalityTrace.VIRTUOUS:
                if (virtuous == null)
                {
                    virtuous = new PersonalityIdentification();
                    virtuous.shortDescription =
                        "Experimentadores práticos e ousados, mestres em todos tipos de ferramentas.";
                }
                return virtuous;
            case PersonalityTrace.ADVENTURER:
                if (adventurer == null)
                {
                    adventurer = new PersonalityIdentification();
                    adventurer.shortDescription =
                        "Artistas flexíveis e charmosos, sempre prontos para explorar e experimentar " +
                        "algo novo.";
                }
                return adventurer;
            case PersonalityTrace.ENTREPRENEUR:
                if (entrepreneur == null)
                {
                    entrepreneur = new PersonalityIdentification();
                    entrepreneur.shortDescription =
                        "Pessoas inteligentes, enérgicas e perceptivas, que realmente gostam de arriscar.";
                }
                return entrepreneur;
            case PersonalityTrace.ENTERTAINER:
                if (entertainer == null)
                {
                    entertainer = new PersonalityIdentification();
                    entertainer.shortDescription =
                        "Animadores entusiasmados, enérgicos e espontâneos - a vida nunca fica" +
                        " entediante perto deles.";
                }
                return entertainer;
            default:
                throw new ArgumentOutOfRangeException("trace", trace, null);
        }
    }
}