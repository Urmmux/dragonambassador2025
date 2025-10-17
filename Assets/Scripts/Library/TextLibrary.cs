using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextLibrary : MonoBehaviour
{
    // for getting random text picks, first assign the default, meets-no-conditions, failsafe string
    //then check conditions for different text, going from lowest priority to the highest, so that higher priorities override the lower ones
    public static string GetStartBattleText(DragStats attackerStats, DragStats defenderStats){
        string randomTextPick = "The halls of the lair echo with the roar of flame and beast. You arrived just in time.";
        
        //add conditions for sloth, and death grievance

        if (Random.Range(2, 4) < defenderStats.honor){
            randomTextPick = $"{defenderStats.dragName} stands ready to accept the outcome, whatever it might be.";
            if (defenderStats.playerAffection > 60){
                randomTextPick = $"{defenderStats.dragName} stands ready to accept the outcome, whatever it might be. She's conflicted about you being here. This is her fight, not yours, but a smile escapes her anyway.";
                if (Random.Range(2, 4) < defenderStats.honor){
                    return randomTextPick;
                }
            }
        }

        if (Random.Range(1, 6) < attackerStats.social) {
            randomTextPick = $"{attackerStats.dragName} frowns. She didn't want things to come to this. She didn't want you to see this.";
            if (attackerStats.playerAffection < 60){
                randomTextPick = $"{attackerStats.dragName} frowns. She didn't want things to come to this.";
            } else if (Random.Range(1, 4) <  attackerStats.social) {
                return randomTextPick;
            }
        }

        if (attackerStats.playerAffection >= 60){
            randomTextPick = $"{attackerStats.dragName} looks to you briefly, and confidently.";
        }
        if (defenderStats.playerAffection >= 60){
            if (defenderStats.power < attackerStats.power) {
                randomTextPick = $"{defenderStats.dragName} supresses a smile when they catch sight of you. There's a glimmer of hope for them after all.";
            }
            if (defenderStats.power >= attackerStats.power) {
                randomTextPick = $"{attackerStats.dragName} glances toward you, and hesitates. She shows a shadow of worry, just for a second";
            }
        }
        if (attackerStats.playerAffection >= 70){
            randomTextPick = $"{attackerStats.dragName} knew you'd be here.";
            if (Random.Range(1, 7) < attackerStats.brutality) {
                randomTextPick = $"{attackerStats.dragName} laughs gleefully as {defenderStats.dragName} starts to panic.";
            }
        }
        if (defenderStats.playerAffection >= 70){
            randomTextPick = $"{defenderStats.dragName} is noticeably relieved as soon as you show up.";
        }
        if (attackerStats.playerAffection >= 80){
            randomTextPick = $"{attackerStats.dragName} is on the defensive. Of course, she was just waiting for you.";
            if (Random.Range(1, 7) < attackerStats.brutality) {
                 randomTextPick = $"{attackerStats.dragName} is glad you're here. She was holding off on all the fun until you arrived.";
            }
        }
        if (defenderStats.playerAffection >= 80){
            randomTextPick = $"As soon as {defenderStats.dragName} sees you, she throws off {attackerStats.dragName} with a sudden surge of strength. Then she rushes to your side.";
        }
        if (defenderStats.dreamer && Random.Range(70, 180) > defenderStats.playerAffection + attackerStats.playerAffection) {
            randomTextPick = $"{defenderStats.dragName} speaks authoritatively. This was always the way it ended. She doesn't say for whom, but she knows. A low whisper finds its way to your ear. {GetRandomProphecy(attackerStats)}";
        }


        return randomTextPick;
    }

    public static string GetUneventfulGreeting(DragStats dragon){
        List<string> greetings = new List<string>();
        if (dragon.playerAffection < 20){
            greetings.Add("You better have a good reason for coming here.");
            greetings.Add("I have little patience for this. The Great Arbitration was a mistake.");
            greetings.Add("There's no reason some insolent human should get under my scales the way you do.");
            greetings.Add("Of course you crawled in here. I was almost about to enjoy today.");
            if (dragon.brutality == 4){
                greetings.Add("I will rip the flesh from your bones one day.");
            }
            if (dragon.jealousy == 3){
                greetings.Add("You... The other dragons sent you here, didn't they. They're toying with me.");
            }
            if (dragon.moody){
                greetings.Add("I did not need this today. Looking at you makes the headache worse.");
            }
            if (dragon.social == 3){
                greetings.Add("Hmm... I'll talk, but only because I must. Ambassador is such a useless job. I'm sure we could work this out without you.");
            }
            if (dragon.social == 1){
                greetings.Add("...Just leave me alone. I just wanted to be alone.");
            }
            if (dragon.boredom >= 3){
                greetings.Add("Oh, it's you... I hoped one of my rivals finally got the nerve to come here. I'm getting so tired of all this.");
            }
            if (dragon.moody){
                greetings.Add("I can't STAND IT ANYMORE. Stay back or I might do something rash.");
            }
            if (dragon.honor == 4){
                greetings.Add("Be quick. It will take me ages to get the stain of your disgrace out of my floors.");
                greetings.Add("You were never worthy of the ambassador title. I'll never understand how you got chosen.");
            }
            if (dragon.honor == 1){
                greetings.Add("You made a brave choice coming here. I won't follow the rules forever.");
            }
            if (dragon.intolerant){
                greetings.Add("This little rat dares to speak to me. One day I'll be rid of vermin.");
                greetings.Add("So it's the ambassador. Out of all the little pests that scatter across my lands, you're somehow the worst one.");
                greetings.Add("More ape-stink. The smell makes me sick.");
            }
        } else if (dragon.playerAffection < 30){
            greetings.Add("Oh it's you. I'm starting to doubt the wisdom of calling for arbitration.");
            greetings.Add("The ambassador is here. Did you come here to set things right?");
            greetings.Add("I should have guessed it was you today. A pity...");
            greetings.Add("You could just leave. You don't have to be here.");
            greetings.Add("Why visit here? Did the other dragons lose their patience already?");
            if (dragon.vainity == 3){
                greetings.Add("Ugh, the ambassador. I'm not sure you appreciate the magnificence of the dragon before you.");
                greetings.Add("You better have brought a gift.");
            }
            if (dragon.jealousy == 3){
                greetings.Add("You've been talking to other dragons, haven't you? I can smell it.");
                greetings.Add("What are you scheming this time?");
            }
            if (dragon.sloth){
                greetings.Add("Can you just come back tomorrow? I don't have the energy for this.");
            }
            if (dragon.moody){
                greetings.Add("I did not need this today. Looking at you makes the headache worse.");
                greetings.Add("It's you?! No no no no NO NO NO NO! Ok. It's ok...");
            }
            if (dragon.honor == 1){
                greetings.Add("You made a brave choice coming here. I won't follow the rules forever.");
            }
            if (dragon.reader){
                greetings.Add("Hurry up. I was in the middle of a story.");
            }
            if (dragon.honor == 3){
                greetings.Add("Go ahead and speak. You have a right to talk to me, for now.");
            }
            if (dragon.intolerant)
            {
                greetings.Add("An unimpressive human, like the rest.");
                greetings.Add("Hurry. Mammals like you tend to carry fleas.");
                greetings.Add("More ape-stink. The smell makes me sick.");
            }
        }else if (dragon.playerAffection < 50) {
                greetings.Add("Ambassador. What have you come to discuss?");
                greetings.Add("Oh, the human arbitrator. Very well then, what is it?");
                greetings.Add("Hmm... you require something of me?");
                if (dragon.brutality >= 3)
                {
                    greetings.Add("The ambassador... I would have preferred to handle things by blood.");
                }
                if (dragon.brutality == 1)
                {
                    greetings.Add("I just hope we all get through this safely.");
                    greetings.Add("Do what you can, human, to keep the peace.");
                }
                if (dragon.vainity == 3)
                {
                    greetings.Add("Oh perfect. You agree that I should be the new Dragon Queen, right?");
                    greetings.Add("The other dragons, they must be so awful compared to me. I'm sorry you have to deal with them.");
                }
                if (dragon.jealousy == 3)
                {
                    greetings.Add("You're here on behalf of everyone, right? Including me?");
                    greetings.Add("If they others have told you anything about me, they're lying.");
                }
                if (dragon.ruler)
                {
                    greetings.Add("Kneel. Good little human. Now, what did you need?");
                }
                if (dragon.expansionist == 3)
                {
                    greetings.Add("Our last Queen left so much land. I should act quickly.");
                }
                if (dragon.collector)
                {
                    greetings.Add("Hello Ambassador. Do you have any pretty treasures today?");
                    greetings.Add("I hope nothing gets lost in all the chaos.");
                }
                if (dragon.sloth || dragon.moody)
                {
                    greetings.Add("Oh, Ambassador. You woke me up. What do you need?");
                }
                if (dragon.sloth)
                {
                    greetings.Add("I hope you aren't asking too much of me today.");
                    greetings.Add("I was thinking of sleeping through tomorrow.");
                }
                if (dragon.social == 3)
                {
                    greetings.Add("Don't worry, I'm sure we can work this out.");
                    greetings.Add("Ah the ambassador! Maybe people will start listening to me now.");
                    greetings.Add("I have high hopes for the Great Arbitration. Don't let me down.");
                }
                if (dragon.social == 1)
                {
                    greetings.Add("If you're the ambassador, you'll do all the talking for me, right?");
                    greetings.Add("Oh, a visitor. Do we have to do this now? Fine, go ahead.");
                }
                if (dragon.moody && Random.Range(1, 4) == 1)
                {
                    greetings.Add("Speak quietly, my head is pounding today.");
                    greetings.Add("Ok... it should be fine to talk right now. Lucky.");
                    greetings.Add("I NEED everything to be still today! Don't move a muscle!");
                }
                if (dragon.traveler && Random.Range(1, 3) == 1)
                {
                    greetings.Add("Have you come far? Please tell me all about it...");
                }
                if (dragon.boredom >= 4 || dragon.moody)
                {
                    greetings.Add("I'm getting tired of all this waiting around...");
                }
                if (dragon.honor == 1)
                {
                    greetings.Add("Trust me, Ambassador, there's no room for hesitation anymore. Do what it takes to get ahead.");
                    greetings.Add("No price is too high when there's this much at stake.");
                }
                if (dragon.honor == 4)
                {
                    greetings.Add("I trust that order shall be restored soon, Ambassador.");
                    greetings.Add("We are writing history as we speak. You should be honored.");
                }
                if (dragon.intolerant && Random.Range(1, 4) == 1)
                {
                    greetings.Add("Let's make one thing clear. Humans are good for one thing only. Stick to resolving disputes and let's hope this is over with soon.");
                    greetings.Add("You better prove you're different than other apes...");
                    greetings.Add("Hurry. Mammals like you tend to carry fleas.");
                }
            } else if (dragon.playerAffection < 70) {
                greetings.Add("I was hoping to see you today.");
                greetings.Add("Make yourself at home, Ambassador.");
                greetings.Add("Come to admire my hoard, Ambassador? Look all you want...");
                greetings.Add("It's warmer inside the lair? I didn't notice.");
                greetings.Add("I really don't mind when you show up.");
                if (dragon.brutality >= 3)
                {
                    greetings.Add("I was thinking about eating the guts of your enemies for dinner tonight. What do you think?");
                    greetings.Add("Just say the word and I'll waste them all");
                }
                if (dragon.brutality >= 2)
                {
                    greetings.Add("Humans eat deer, right? I've got plenty of deer right now.");
                }
                else
                {
                    greetings.Add("Humans like food cooked, right? With fruit and seaweed? Could you show me?");
                }
                if (dragon.vainity == 3)
                {
                    greetings.Add("It's only fitting that such an important human finds himself at my lair.");
                    greetings.Add("I deem you worthy of my presence");
                }
                if (dragon.jealousy == 3)
                {
                    greetings.Add("You should just stay here, where the others can't get you.");
                    greetings.Add("They can't stop you from coming here. You should visit more often.");
                }
                if (dragon.vainity == 1 && dragon.jealousy == 1)
                {
                    greetings.Add("This might sound strange, but I hope you are getting along with other dragons too, not just me.");
                }
                if (dragon.collector)
                {
                    greetings.Add("I've reorganized my hoard last night. Let me show you.");
                    greetings.Add($"you really appreciate ${dragon.favTreasure}s too, don't you? Not everyone understands");
                }
                if (dragon.sloth)
                {
                    greetings.Add("Come in! You must be tired. Let's rest for a while.");
                }
                if (dragon.romantic)
                {
                    greetings.Add("Do dragons interest you, Ambassador?");
                    greetings.Add("You should really think about what you're going to do after the Great Arbitration. Do you have some place to settle down to?");
                    greetings.Add("I really like you, dear Ambassador. You like me too, right?");
                }
                if (dragon.proactivity == 3 && dragon.romantic)
                {
                    greetings.Add("I think my tail is the most flexible part of my body. There's all sorts of things it can do.");
                    greetings.Add("Oh Ambassador, I think I'm starting to shed. Can you help me? Just massage a bit... right... here... ");
                }
                if (dragon.ruler)
                {
                    greetings.Add("Kneel. Good little human. Now, what did you need?");
                }
                if (dragon.moody)
                {
                    greetings.Add("Good timing. I was just getting confused.");
                    greetings.Add("Everything just seems clearer when you're around.");
                    greetings.Add("If I say something strange, just ignore it.");
                    greetings.Add("This isn't fair. You should leave.");
                }
                if (dragon.traveler)
                {
                    greetings.Add($"When this is over, remind me to fly you to the ${GetRandomDistantLoc(dragon)}. You must see it.");
                }
                if (dragon.traveler && dragon.shifter)
                {
                    greetings.Add("I've always wanted to live in a human city. You'd help me, right?");
                }
                if (dragon.reader)
                {
                    greetings.Add("I hope they write stories about us.");
                    greetings.Add("I can help you with any tomes, if you need.");
                }
                if (dragon.honor == 4)
                {
                    greetings.Add("It's rare to find a respectable human, like you.");
                    greetings.Add("If anyone can bring order to this mess, it's you.");
                    greetings.Add("I am at your service, Ambassador. Whatever you require.");
                }
                if (dragon.intolerant)
                {
                    greetings.Add("I'm making an exception for you. You're welcome here any time.");
                    greetings.Add("You don't stink like the other humans. I almost like the way you smell.");
                }
                if (dragon.scaleColor == 6 || dragon.eyeColor == 6)
                {
                    greetings.Add("Hmmm... The deer have all been migrating today.");
                    greetings.Add("I think it's going to storm tomorrow. I wonder if I should go hunting then.");
                }
                if (dragon.scaleColor == 5 || dragon.eyeColor == 5)
                {
                    greetings.Add("If another hero chips my beautiful scales again I'm going to drop them into the middle of the sea.");
                    greetings.Add("It's going to be quite cold tonight. I can shelter you under my wings.");
                }
                if (dragon.scaleColor == 4 || dragon.eyeColor == 4)
                {
                    greetings.Add("It's strange that you aren't afraid of us, but I'm glad.");
                    greetings.Add("I think I saw the thunderbird yesterday, just a glimpse.");
                }
                if (dragon.scaleColor == 3 || dragon.eyeColor == 3)
                {
                    greetings.Add("I was swimming at the bottom of a river yesterday, when a whole galleon passed overhead. They didn't even see me!");
                    greetings.Add("I found an old anchor, covered in algae, and felt compelled to add it to my hoard.");
                }
                if (dragon.scaleColor == 2 || dragon.eyeColor == 2)
                {
                    greetings.Add("Something’s been digging near the base of the cliffs. It's not me this time.");
                    greetings.Add("I've noticed there are more bats than usual in the caves nearby.");
                }
                if (dragon.scaleColor == 1 || dragon.eyeColor == 1)
                {
                    greetings.Add("The cities seemed crowded today. Is there some kind of human holiday going on?");
                    greetings.Add("I wonder if there's going to be another eclipse this year?");
                }
            } else {
                greetings.Add("Hello dear!");
                greetings.Add("Welcome back. Miss me?");
                greetings.Add("My treasure hoard is only complete when you stop by.");
                greetings.Add("I'm so glad you're here, Ambassador.");
                if (dragon.brutality == 4)
                {
                    greetings.Add("I was thinking about eating the guts of your enemies for dinner tonight. What do you think?");
                    greetings.Add("Who do you need dead? I'll do it just for you.");
                    greetings.Add("I always want you by my side in a fight.");
                }
                if (dragon.brutality >= 2)
                {
                    greetings.Add("Humans eat deer, right? I've got plenty of deer right now.");
                }
                else
                {
                    greetings.Add("Humans like food cooked, right? With fruit and seaweed? Could you show me?");
                }
                if (dragon.vainity == 3)
                {
                    greetings.Add("Praise me again, Ambassador.");
                    greetings.Add("Finally someone really sees how great I am.");
                    greetings.Add("You made the right choice trusting me, I promise.");
                    greetings.Add("You are the only one worthy of my love.");
                }
                if (dragon.vainity == 1)
                {
                    greetings.Add("I don't know if I would have made it through without you, Ambassador.");
                }
                if (dragon.jealousy == 3)
                {
                    greetings.Add("They want to steal you from me, I know it...");
                    greetings.Add("They'd never understand what we have.");
                    greetings.Add("I don't want you talking to the other dragons anymore.");
                    greetings.Add("One day I'll keep you here, where nobody else can get you...");
                }
                if (dragon.sloth)
                {
                    greetings.Add("Come back to bed with me. Let's take a nap together.");
                    greetings.Add("Running around like you do sounds so exhausting. You can always come here to take a break, my dear.");
                    greetings.Add("It's going to storm tonight. Let's listen to the rain together.");
                    greetings.Add("I haven't moved all day. I was waiting for you.");
                }
                if (dragon.collector)
                {
                    greetings.Add($"you really appreciate ${dragon.favTreasure}s too, don't you? Not everyone understands");
                    greetings.Add($"I want to know everything about you. What do you think about ${dragon.favColor} ${dragon.favTreasure}s? I could talk about them forever.");
                    greetings.Add("I like to think of it as our hoard, not just mine.");
                }
                if (dragon.romantic)
                {
                    greetings.Add("I do love you, Ambassador");
                    greetings.Add("You've already made my dreams come true, my dear Ambassador");
                    greetings.Add("Just let me hold you for a minute.");
                    greetings.Add("I hope you don't have big plans tonight, Ambassador...");
                    greetings.Add("I think my tail is the most flexible part of my body. There's all sorts of things it can do.");
                    greetings.Add("Oh Ambassador, I think I'm starting to shed. Can you help me? Just massage a bit... right... here... ");
                }
                if (dragon.ruler)
                {
                    greetings.Add("Kneel. Good little human. I love it when you obey.");
                    greetings.Add("Obediant little darling, aren't you?");
                    greetings.Add("Cook me dinner tonight. If you do a good job, I'll let you kiss my tail.");
                }
                if (dragon.social == 1)
                {
                    greetings.Add("You're the only person I need.");
                    greetings.Add("I don't feel so alone with you around.");
                }
                if (dragon.moody)
                {
                    greetings.Add("Good timing. I was just getting confused.");
                    greetings.Add("Everything just seems clearer when you're around.");
                    greetings.Add("If I say something strange, just ignore it.");
                    greetings.Add("Whenever I drift too far, I think of you. You're my anchor.");
                    greetings.Add("I HATE... no, no I don't. I'm sorry, ignore that.");
                    greetings.Add("Everything is so loud today. Just whisper what you need.");
                    greetings.Add("Thanks for being so patient with me.");
                }
                if (dragon.traveler)
                {
                    greetings.Add("I can't wait to see all the world with you.");
                    greetings.Add($"When this is over, remind me to fly you to the ${GetRandomDistantLoc(dragon)}. You must see it.");
                }
                if (dragon.reader)
                {
                    greetings.Add("Oh, hello. Read any good books lately?");
                    greetings.Add("You can borrow anything you want from my library. I trust you'll return it.");
                    greetings.Add("It's odd. None of my studies prepared me for someone like you.");
                    greetings.Add($"Did you know that ${RetrieveNerdyFact()}?");
                }
                if (dragon.intolerant)
                {
                    greetings.Add("I started to miss the way you smell. It's intoxicating.");
                    greetings.Add("Maybe humans aren't a bad thing.");
                    greetings.Add("I'm trying to be nicer to other humans, because of you.");
                }
                if (dragon.favColor == "Blue" || dragon.affinity == "nature" || dragon.affinity == "lightning")
                {
                    greetings.Add("Can you rub the base of my horns? They're a bit sore today.");
                }
                if (dragon.favColor == "Green" || dragon.affinity == "ice" || dragon.affinity == "nature")
                {
                    greetings.Add("I like it when I feel the warmth of your hands against my wings.");
                    greetings.Add("I always wondered what it would be like to live in the Age of Nume.");
                }
                if (dragon.favColor == "Gold" || dragon.affinity == "void" || dragon.affinity == "fire")
                {
                    greetings.Add("I need you to polish my scales. I don't trust anyone else to do that.");
                    greetings.Add("Can you rub the base of my horns? They're a bit sore today.");
                }
                if (dragon.favColor == "Red" || dragon.affinity == "ice")
                {
                    greetings.Add("I need you to polish my scales. I don't trust anyone else to do that.");
                    greetings.Add("When I was younger, I met a prince from the Kingdom of Virtue who looked a lot like you");
                }
                if (dragon.favColor == "white" || dragon.affinity == "lightning")
                {
                    greetings.Add("I always wondered what it would be like to live in the Age of Nume.");
                    greetings.Add("I like to fly above the clouds in the middle of the night sometimes, forget about the world below, and just wonder at the stars.");
                }
                if (dragon.scaleColor == 1 || dragon.eyeColor == 6)
                {
                    greetings.Add("My mother told me the secret to a long life was properly-brewed tea and a healthy respect for secrets.");
                    greetings.Add("My first hoard was just a bunch of shiny rocks. I still have a few if you want to see.");
                }
                if (dragon.scaleColor == 2 || dragon.eyeColor == 5)
                {
                    greetings.Add("I got hopelessly lost in a cave underneath the mountains one time. Going weeks without seeing the sky was... difficult.");
                    greetings.Add("I hate when I lose a tooth. It'll grow back, but for weeks it feels like something is missing...");
                }
                if (dragon.scaleColor == 3 || dragon.eyeColor == 4)
                {
                    greetings.Add("Wait... I really wasn't expecting you. The lair is such a mess right now. Don't look!");
                    greetings.Add("Deer are the most common thing to hunt, but sometimes I go straight to the water and just catch fish.");
                }
                if (dragon.scaleColor == 4 || dragon.eyeColor == 3)
                {
                    greetings.Add("There’s a spot in my lair where the acoustics are perfect for singing. Dragons don't have many songs though, can you teach me some human ones?");
                    greetings.Add("There is a tree older than I am out by the edges of my territory. I think it will outlive me, too...");
                }
                if (dragon.scaleColor == 5 || dragon.eyeColor == 2)
                {
                    greetings.Add("The legend is that a carp that ascends seven waterfalls becomes a dragon, but I haven't met any dragon that admits they used to be a fish.");
                    greetings.Add($"I think a ${dragon.favTreasure} in my hoard is cursed. Don't worry, it should be fine, just try not to touch it.");
                }
                if (dragon.scaleColor == 6 || dragon.eyeColor == 1)
                {
                    greetings.Add("You have such an adorable accent. Tell me more about where you're from...");
                    greetings.Add("I've been sketching a drawing of you in this blank tome. I think it's my favorite tome now...");
                }

            }
        greetings.Add("Hello Ambassador.");
        return greetings[Random.Range(0, greetings.Count)];
    }

    public static string RetrieveNerdyFact(){
        List<string> facts = new List<string>();
        facts.Add("fungal forests grow where titans are buried");
        facts.Add("the third king of Nume, Loraxon Ellit, was the first human to talk to a dragon");
        facts.Add("young ice worms can become sand worms if they grow in low-water environments");
        facts.Add("despite Nume having many magically-animated creations, the fearsome golem actually predates all Numian culture");
        facts.Add("maneaters sense their environment purely through heat and vibrations");
        facts.Add("the pirate lord Triple-barrel Kainee kept the skull of her mother in her cabin");
        facts.Add("the third eye of a goblin sees time happening in reverse");
        facts.Add("the rock of the Great Mountain Ilsacang dreams of becoming flesh and bone");
        facts.Add("the first books were written as a way to store spells");
        facts.Add("the last human kingdom that used to rule over this land, the kingdom of Virtue, only lasted a tenth of the time that Nume did");
        facts.Add("the late dragon queen had three seperate meetings with the king of Virtue");
        facts.Add("kitsune grow one tail for each century they are live, but only one kitsune has ever reached nine tails");
        facts.Add("ghasts are a type of ghost that only remembers the last few moments of when it was alive");
        facts.Add("children of Quarrash could shoot a bow from horseback by age 7");
        facts.Add("Loraxon Ellit thought that kobolds used to be dragons, but had their wings stolen from them by a vengeful god");
        facts.Add("the Vill believe that if you attain a high enough rank of enlightenment, you stop needing to eat or drink");
        facts.Add("vampires do exist, but they can only be seen in reflections");
        facts.Add("the earliest humans used giant mushroom spores as ink, and humans that wrote too much would start having hallucinations");
        return facts[Random.Range(0, facts.Count)];
    }

    public static string GetRandomDistantLoc(DragStats dragon){
        if (dragon.favColor == "Blue") return "glimmering shores of Tian-xou Pearl Bay, where the water glows under the waxing moon";
        if (dragon.favColor == "Green") return "gloom-tree of the Great Eastern Forest, said to guide the spirits of the departed into the underworld with its roots";
        if (dragon.favColor == "Gold") return "ruins of Zemarra Academy tower, where the greates Numian minds gathered";
        if (dragon.favColor == "Red") return "frozen peak of Stharkhand, under the dazzling northern lights";
        if (dragon.favColor == "white") return "sacred shrine of the nine-tailed kitsune, home to powerful spirits";
        return "error";
    }

    public static string GetRandomProphecy(DragStats about)
    {
        List<string> prophecies = new List<string>();

        if (about.power >= 18)
            prophecies.Add($"{about.dragName} carries great power. Her name will be remembered in books of the future.");
        else if (about.power <= 12) {
            prophecies.Add($"{about.dragName} is the eyes on a moth's wing.");
            prophecies.Add($"{about.dragName} is desperate to keep up with the turning of the wheel.");
            prophecies.Add($"I do not fear {about.dragName}. Not every dragon is worthy of the terror of their name");
        }

        if (about.wealth > 20)
            prophecies.Add($"The hoard of {about.dragName} rivals that of the heavens.");

        if (about.romantic)
            prophecies.Add($"{about.dragName} has always longed for a treasure not held with one's claws.");
        if (about.playerAffection >= 75)
            prophecies.Add($"{about.dragName} and you share a close bond. ...Is a new age coming?");
        else if (about.playerAffection <= 19)
            prophecies.Add($"{about.dragName} wont rest until the earth reclaims you.");
        
        if (about.brutality >= 4)
            prophecies.Add($"{about.dragName} has a heart like a labyrinth. A nest fit for wasps.");
        else if (about.brutality <= 2)
            prophecies.Add($"{about.dragName} fights more like a mantis than a dragon. A prayer before every strike.");

        if (about.vainity >= 3){
            prophecies.Add($"{about.dragName} has a nightmare that she no longer sees her face in the still water.");
            prophecies.Add($"{about.dragName} is a construct, the real one is inside of her.");
        }

        if (about.ruler){
            prophecies.Add($"It's not the gold for {about.dragName}, it's seeing all the people doing as they should.");
            prophecies.Add($"{about.dragName} is fascinated by the sandcastles building up and washing out over time.");
        }

        if (about.traveler)
            prophecies.Add($"Home has a much different meaning for {about.dragName}. Is she not content with her lair?");

        if (about.resurrectionist)
            prophecies.Add($"{about.dragName} has visions of death, and whispers to it like an old friend.");

        if (about.reader) {
            prophecies.Add($"{about.dragName} knows all the dead languages that weave together a spell.");
            prophecies.Add($"{about.dragName} can be truly lost in the stories she reads.");
            prophecies.Add($"{about.dragName} hoards memories just as much as gold.");
        }

        if (about.intolerant)
            prophecies.Add($"{about.dragName} has little patience for the rats infesting her land.");

        if (about.collector){
            prophecies.Add($"{about.dragName} finds meaning where others find only value.");
            prophecies.Add($"Over time, {about.favTreasure}s crawl toward {about.dragName} like roots toward water.");
        }

        if (about.shifter){
            prophecies.Add($"{about.dragName} is reborn by her own womb again and again.");
            prophecies.Add($"Where does {about.dragName} get all her different skins?.");
        }

        if (about.sloth){
            prophecies.Add($"{about.dragName} speaks to the mountains and the trees, and has little time for the mayflies.");
            prophecies.Add($"{about.dragName} is blind to the flow of time around her.");
        }

        if (about.dreamer) {
            prophecies.Add($"Last night, I saw {about.dragName}, and she looked back at me.");
            prophecies.Add($"{about.dragName} and I have pieces of the same broken mirror.");
        }

        if (about.moody) {
            prophecies.Add($"{about.dragName} lies under the wandering star.");
            prophecies.Add($"{about.dragName} has a soul painted by the ancient fae.");
        }

        if (about.boredom >= 5)
            prophecies.Add($"She grows restless. {about.dragName} yearns to act.");

        if (about.confidence >= 3)
            prophecies.Add($"{about.dragName} seems to think the world will bend to her will");

        if (about.jealousy >= 3) {
            prophecies.Add($"{about.dragName} is insulted when the frog sings for his mate. The songs should be for her.");
            prophecies.Add($"{about.dragName} knows the branches in the other bird's nests. She'll never let them go.");
        }

        if (prophecies.Count >= 2)
            prophecies.Add($"{about.dragName} hides more than she shows. Her face is dark to me.");

        return prophecies[Random.Range(0, prophecies.Count)];
    }
}
