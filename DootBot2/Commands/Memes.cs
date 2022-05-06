﻿using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Interactivity.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Audio;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using DSharpPlus.VoiceNext;

namespace DootBot2.Commands
{
    class Memes : BaseCommandModule
    {

        List<string> meamea = new List<string>
        {
       "https://cdn.discordapp.com/attachments/268400938799071232/966741059524784178/trim.AF6FFD17-A012-45A8-84E8-E534F23D97B1.mov",
       "https://cdn.discordapp.com/attachments/439519668819066880/966515525637271594/video0-3.mp4",
       "https://cdn.discordapp.com/attachments/967031855985590383/967529569483636816/IMG_1399.mp4",
       "https://cdn.discordapp.com/attachments/967031855985590383/967529557357916181/IMG_1411.mp4",
       "https://cdn.discordapp.com/attachments/956994953727336448/966965248231866368/nAXej9HO1CMLkICI.mp4",
       "https://cdn.discordapp.com/attachments/967031855985590383/967530558689263727/IMG_1409.mp4",
       "https://cdn.discordapp.com/attachments/967031855985590383/967534300755034162/trim.DDA0C5EA-C99F-4963-90C2-5B5A5EBB2202.mov",
       "https://cdn.discordapp.com/attachments/967031855985590383/967533125242605678/trim.56D17733-A7E8-4C51-B9B3-07A1EAE07E22.mov",
       "https://cdn.discordapp.com/attachments/967031855985590383/967532922825486346/trim.2D9D33EB-C50E-4FA0-8E1C-4B736CF3DEE7.mov",
       "https://cdn.discordapp.com/attachments/967031855985590383/967534534973341806/trim.33EB4EB9-BE5C-4ADA-AB52-DA7F318DCF80.mov",
       "https://cdn.discordapp.com/attachments/967031855985590383/967533589568823406/trim.689E2E3D-13D8-47A4-B3D0-958F67875ADF.mov",
       "https://cdn.discordapp.com/attachments/967031855985590383/967534940021485578/trim.60FAB7A3-2EE4-4140-8352-BEC8D051767C.mov",
       "https://cdn.discordapp.com/attachments/967031855985590383/967532845021147246/trim.120ED666-7A5E-4283-B41B-DCE3D8533FDD.mov",
       "https://cdn.discordapp.com/attachments/967031855985590383/967535439047192637/trim.1A5FD7AC-066B-4A99-A7D5-5B67C4580B6D.mov",
       "https://cdn.discordapp.com/attachments/967031855985590383/967538644388831242/trim.40779396-D70C-47E7-81F1-CCEC549E125E.mov",
       "https://cdn.discordapp.com/attachments/967031855985590383/967538210592935986/ECE51BE8-BD25-4D95-8582-5B5CC63B0FB6.jpg",
       "https://cdn.discordapp.com/attachments/967031855985590383/967537719590940752/B8893A96-8899-4B7D-8717-09C282FC60D9.jpg",
       "https://cdn.discordapp.com/attachments/967031855985590383/967537484185604106/trim.0A107327-E1B6-4AFC-919B-5C222B9258DB.mov",
       "https://cdn.discordapp.com/attachments/967031855985590383/967537417835913356/trim.2F003B64-7674-4C57-986A-833FC61DCCE1.mov",
       "https://media.discordapp.net/attachments/268400938799071232/966414805411987487/unknown.png",
       "https://cdn.discordapp.com/attachments/634063767466147840/968099529255690260/Microwave.mp4",
       "https://cdn.discordapp.com/attachments/603080990117855251/966899312263049217/0J07y76gZ9uRHOn-.mp4",
       "https://cdn.discordapp.com/attachments/953513218666561556/967021644587597914/Valid_Arguement.mp4",
       "https://cdn.discordapp.com/attachments/956994953727336448/968090828176248832/discordVideos-u7plkl.mp4",
       "https://cdn.discordapp.com/attachments/967031855985590383/967529582825705542/IMG_1391.mp4",
       "https://cdn.discordapp.com/attachments/967031855985590383/967530122318082088/trim.15C0EC44-CCBF-4B89-B123-82DE2624B1C8.mov",
       "https://cdn.discordapp.com/attachments/967031855985590383/968241531041493062/IMG_1438.mp4",
       "https://cdn.discordapp.com/attachments/967031855985590383/968242961429172344/172D7291-6076-42E1-8B85-D0E69A3828AA.jpg",
       "https://cdn.discordapp.com/attachments/967031855985590383/968242665298722816/wolfenstein_London_meme.mp4",
       "https://cdn.discordapp.com/attachments/967031855985590383/968243483754238002/trim.99A0A67C-DB61-4CDD-81F0-BE73F5653AD7.mov",
       "https://cdn.discordapp.com/attachments/967031855985590383/968243429962317884/trim.A25949D9-08B8-4F4A-947C-405A35348946.mov",
       "https://media.discordapp.net/attachments/967031855985590383/968244256709939231/IMG_1443.png?width=513&height=671",
       "https://cdn.discordapp.com/attachments/967031855985590383/968244382811709512/EfHF5izWkAAzsa7.jpg",
       "https://cdn.discordapp.com/attachments/967031855985590383/968244575682572328/B96708BE-EF37-4536-84EB-110EC2D0C9E4.jpg",
       "https://cdn.discordapp.com/attachments/967031855985590383/968244666245980241/6D992679-E8C8-4189-ACB2-1186670F7707.jpg",
       "https://cdn.discordapp.com/attachments/967031855985590383/968245356926206002/A10DCE9C-9EDC-4BDF-B5F8-FEBE45C0A139.jpg",
       "https://cdn.discordapp.com/attachments/967031855985590383/968245406859415672/trim.B6CF0257-CBCF-4702-8A01-B6FFD3B1A5E8.mov",
       "https://cdn.discordapp.com/attachments/967031855985590383/968245487788494909/trim.AD725C88-13CA-42F1-9C5A-D683E05F6BAB.mov",
       "https://cdn.discordapp.com/attachments/967031855985590383/968246470069350450/videoplayback_1.mp4",
       "https://cdn.discordapp.com/attachments/967031855985590383/968246977202638878/videoplayback_2.mp4",
       "https://cdn.discordapp.com/attachments/967031855985590383/968246938438889492/888EEA30-C01A-4C27-88F6-98568D37655F.jpg",
       "https://cdn.discordapp.com/attachments/967031855985590383/968247388777086986/videoplayback_3.mp4",
       "https://cdn.discordapp.com/attachments/967031855985590383/968247960607526952/POV__you_just_started_an_argument_on_twitter.com.mp4",
       "https://cdn.discordapp.com/attachments/967031855985590383/968247986155032596/gs6d56f.mp4",
       "https://cdn.discordapp.com/attachments/967031855985590383/968247995374108712/frogeat.mp4",
       "https://cdn.discordapp.com/attachments/967031855985590383/968248007634067506/Yomama.mov",
       "https://cdn.discordapp.com/attachments/967031855985590383/968249037138575390/trim.A6B18EA0-3F67-4460-B9AF-88A217877DAD.mov",
       "https://cdn.discordapp.com/attachments/953513218666561556/968425009485844501/Screenshot_20220426-101444_Facebook.jpg",
       "https://cdn.discordapp.com/attachments/967031855985590383/968584285881770004/c.mp4",
       "https://cdn.discordapp.com/attachments/967031855985590383/968583999893143663/IMG_1449.mp4",
       "https://cdn.discordapp.com/attachments/967031855985590383/968596215962939452/dog_shivering.mp4",
       "https://cdn.discordapp.com/attachments/967031855985590383/968798135960895558/unknown.png",
       "https://cdn.discordapp.com/attachments/967031855985590383/968798109331255346/unknown.png",
       "https://cdn.discordapp.com/attachments/967031855985590383/968874676736639076/maniac_hamster.mp4",
       "https://cdn.discordapp.com/attachments/932739367775125524/965758494118645820/OUR_FOOD_KEEPS_BLOWING.mov",
       "https://cdn.discordapp.com/attachments/967031855985590383/968875160285380608/purrito.mp4",
       "https://cdn.discordapp.com/attachments/967031855985590383/968875228887396452/pet_the_bush.mp4",
       "https://cdn.discordapp.com/attachments/967031855985590383/968875286210953226/ae.mp4",
       "https://cdn.discordapp.com/attachments/932739367775125524/965684075450998865/piss.mp4",
       "https://media.discordapp.net/attachments/932739367775125524/965651024239009863/unknown.png",
       "https://cdn.discordapp.com/attachments/967031855985590383/968875473805402162/Agua.mp4",
       "https://cdn.discordapp.com/attachments/967031855985590383/968875681360511066/snek_ded.mp4",
       "https://cdn.discordapp.com/attachments/831213786840825857/965123008895287366/Snaptik_7082810950415600942_lmao.mp4",
       "https://cdn.discordapp.com/attachments/967031855985590383/968876579075788880/fislift.mp4",
       "https://cdn.discordapp.com/attachments/967031855985590383/968876476881575986/French.mp4",
       "https://cdn.discordapp.com/attachments/967031855985590383/968876706695897118/dizzy_grandma.mp4",
       "https://cdn.discordapp.com/attachments/967031855985590383/968876900372066364/bulb.mov",
       "https://cdn.discordapp.com/attachments/967031855985590383/968876942721970216/axes.mp4",
       "https://cdn.discordapp.com/attachments/967031855985590383/968877150142861342/basketboll_winter.mp4",
       "https://cdn.discordapp.com/attachments/967031855985590383/968877458545852466/cat_angy.mp4",
       "https://cdn.discordapp.com/attachments/967031855985590383/968878076677210223/unknown.png",
       "https://media.discordapp.net/attachments/967031855985590383/968878159565062225/doing_something_when_being_watched.jpg?width=578&height=669",
       "https://media.discordapp.net/attachments/967031855985590383/968878139474333746/elevator_poop.jpg?width=423&height=670",
       "https://cdn.discordapp.com/attachments/967031855985590383/968879128277311509/nerve.jpg",
       "https://media.discordapp.net/attachments/967031855985590383/968879584470790176/rtx_9080_ti.jpg?width=514&height=670",
       "https://media.discordapp.net/attachments/967031855985590383/968879673826242591/noodle_knit.png?width=564&height=670",
       "https://cdn.discordapp.com/attachments/967031855985590383/968879817258852393/unknown.png",
       "https://cdn.discordapp.com/attachments/967031855985590383/968879853900279818/unknown.png",
       "https://cdn.discordapp.com/attachments/967031855985590383/968879917162954822/unknown.png",
       "https://cdn.discordapp.com/attachments/967031855985590383/968879967372976178/unknown.png",
       "https://cdn.discordapp.com/attachments/967031855985590383/968879977015676998/Toys-day-at-USAs-schools.jpg",
       "https://cdn.discordapp.com/attachments/967031855985590383/968880115222208622/unknown.png",
       "https://cdn.discordapp.com/attachments/967031855985590383/968880125959614545/wheres_rick.png",
       "https://cdn.discordapp.com/attachments/967031855985590383/968880247980298281/Coding.jpg",
       "https://cdn.discordapp.com/attachments/775726645330968586/968690713011314688/unknown.png",
       "https://media.discordapp.net/attachments/967031855985590383/968880727917752340/car_batteries_and_the_ocean.png?width=404&height=670",
       "https://cdn.discordapp.com/attachments/967031855985590383/968881050795262033/cut_dem_teeth.png",
       "https://cdn.discordapp.com/attachments/967031855985590383/968880937117036614/unknown.png",
       "https://media.discordapp.net/attachments/967031855985590383/968881210665336902/vr_fun.jpg?width=496&height=670",
       "https://cdn.discordapp.com/attachments/967031855985590383/968882333560221806/dont_cry.mov",
       "https://cdn.discordapp.com/attachments/967031855985590383/968882796233904209/garfield_lore.mp4",
       "https://cdn.discordapp.com/attachments/967031855985590383/968882819457765446/dankvideos-ucpzpq.mp4",
       "https://cdn.discordapp.com/attachments/967031855985590383/968882923765907476/Glue.mov",
       "https://cdn.discordapp.com/attachments/967031855985590383/968883358992052244/pain.mp4",
       "https://cdn.discordapp.com/attachments/967031855985590383/968883464579457104/psychosalad.mp4",
       "https://cdn.discordapp.com/attachments/967031855985590383/968884275346829372/1650895211058.mp4",
       "https://cdn.discordapp.com/attachments/967031855985590383/968884725013971075/tutel.mp4",
       "https://cdn.discordapp.com/attachments/967031855985590383/968884927569465425/thingamabob.mp4",
       "https://cdn.discordapp.com/attachments/967031855985590383/968885094595047474/they_attac.mp4",
       "https://cdn.discordapp.com/attachments/967031855985590383/968885190262935592/when_atf_agent.mp4",
       "https://cdn.discordapp.com/attachments/775717139214368779/968885705017274438/briish.mp4",
       "https://cdn.discordapp.com/attachments/967031855985590383/968886591063994398/shoe.mp4",
       "https://cdn.discordapp.com/attachments/967031855985590383/968886126544830524/superfly.mp4",
       "https://cdn.discordapp.com/attachments/967031855985590383/968886044760080464/sick_spins.mp4",
       "https://cdn.discordapp.com/attachments/967031855985590383/968887115184214046/stephen_gulag.mp4",
       "https://cdn.discordapp.com/attachments/967031855985590383/968887285410062336/romanian_car_thief.mp4",
       "https://cdn.discordapp.com/attachments/967031855985590383/968887925427298395/Release_the_Quacken.mp4",
       "https://cdn.discordapp.com/attachments/967031855985590383/968888391812911154/oh_crap.mov",
       "https://cdn.discordapp.com/attachments/967031855985590383/968888474461692034/no_making_paper_airplanes_in_class.mp4",
       "https://cdn.discordapp.com/attachments/967031855985590383/968888775906328606/MegaBurg.mp4",
       "https://cdn.discordapp.com/attachments/967031855985590383/968888942738939934/lawnmowing_the_house.mp4",
       "https://cdn.discordapp.com/attachments/831996983027433535/969529029319356456/Border.mp4",
       "https://cdn.discordapp.com/attachments/953513218666561556/969556312662888498/hi_honey.mp4",
       "https://cdn.discordapp.com/attachments/765996402747637760/969621476946870372/39856B00-685C-4148-A1BF-B9EFC7A1510F.jpg",
       "https://cdn.discordapp.com/attachments/731866760806137917/950913990299635792/IMG_3776.png",
       "https://cdn.discordapp.com/attachments/765996402747637760/968907812174463047/unknown.png",
       "https://cdn.discordapp.com/attachments/372668992717848586/738769714108563577/ag5LVvW_460s.png",
       "https://cdn.discordapp.com/attachments/372668992717848586/602349189300617217/k3xzc4pvtur01.jpg",
       "https://cdn.discordapp.com/attachments/765996402747637760/965319108235235328/unknown.png",
       "https://cdn.discordapp.com/attachments/765996402747637760/964557793677963264/20220414_044303.jpg",
       "https://cdn.discordapp.com/attachments/953513218666561556/970353460769869924/5A8D8EFD-1E59-4260-BD67-B49F49D4683D.jpg",
       "https://cdn.discordapp.com/attachments/953513218666561556/970397689571336202/bgoBYyME8F3GCW6z.mp4",
       "https://cdn.discordapp.com/attachments/932739367775125524/970081482687258665/brittish_rap.mov",
       "https://cdn.discordapp.com/attachments/268400938799071232/970600746884169758/roblox-roblox-servers_1.mp4",
       "https://cdn.discordapp.com/attachments/268400938799071232/970426092131340318/The_Sims_3_The_funniest_patch_notes_360p.mp4",
       "https://cdn.discordapp.com/attachments/935989994735169546/970431332696080414/video0-49.mp4",
       "https://cdn.discordapp.com/attachments/935989994735169546/970360403081175161/slight_dent.mov",
       "https://cdn.discordapp.com/attachments/268400938799071232/970398303223181372/cyberpunk.mp4",
       "https://cdn.discordapp.com/attachments/956994953727336448/970581457762394182/IMG_4044.jpg",
       "https://cdn.discordapp.com/attachments/634063767466147840/970576286261051422/VID-20210525-WA0018_1.mp4",
       "https://media.discordapp.net/attachments/88090800226865152/970414046350299166/IMG_7245.png",
       "https://cdn.discordapp.com/attachments/953513218666561556/970432382345805917/m7J8x1V1O9HwnYDZ.mp4",
       "https://cdn.discordapp.com/attachments/232570410464575489/970573782479700029/9065093564_1650152865678-1-4.mp4",
       "https://cdn.discordapp.com/attachments/831213786840825857/970610417544097802/EA28CB0C-0235-44D1-B2D8-7D6D4EFBA52E.jpg",
       "https://cdn.discordapp.com/attachments/967031855985590383/969750789922906132/IMG_1463.jpg",
       "https://cdn.discordapp.com/attachments/967031855985590383/969278867506335744/unknown.png",
       "https://cdn.discordapp.com/attachments/929807268994744340/970609178810941450/slip.mp4",
       "https://cdn.discordapp.com/attachments/232570410464575489/970427046138355812/seal_of_mario.mp4",
       "https://cdn.discordapp.com/attachments/232570410464575489/970432453422497843/trim.BDB94254-44B3-400B-B649-34EBAD9023C5.mov",
       "https://cdn.discordapp.com/attachments/929807268994744340/970607124596031518/literally_me.mp4",
       "https://cdn.discordapp.com/attachments/956994953727336448/970621328581361664/Hes_gonna_destroy_the_earth_for_the_funny.mp4",
       "https://cdn.discordapp.com/attachments/956994953727336448/970621661667790848/cat_heart.mov",
       "https://cdn.discordapp.com/attachments/956994953727336448/970621855738232842/glory_to_the_waterland.mp4",
       "https://cdn.discordapp.com/attachments/856186882082078741/969734732311048222/IMG_2931.png",
       "https://media.discordapp.net/attachments/956994953727336448/970627946777829376/society_1.jpg?width=669&height=670",
       "https://cdn.discordapp.com/attachments/956994953727336448/970628113123905567/redditsave.com_metal-1z549bc940x81.mp4",
       "https://cdn.discordapp.com/attachments/956994953727336448/970628096011161630/redditsave.com_enchantment_compilation-x2o2225y3vw81.mp4",
       "https://cdn.discordapp.com/attachments/956994953727336448/970628511456976896/redditsave.com_cursed_rat-oj21ecz2y4w81.mp4",
       "https://cdn.discordapp.com/attachments/956994953727336448/970628803359547402/Ka-boom_rico.jpg",
       "https://cdn.discordapp.com/attachments/933080307219972146/963866622722998312/trim.762214D6-36E3-497F-AD60-E48AF3B3893E.mov",
       "https://cdn.discordapp.com/attachments/933080307219972146/963886504873177108/trim.87AB33C4-5876-4482-85E7-3D4293F88F42.mov",
       "https://cdn.discordapp.com/attachments/933080307219972146/963893243597164565/nom.mp4",
       "https://cdn.discordapp.com/attachments/933080307219972146/963914235983822968/23F05526-2AB7-4EF9-9C4B-8BE0FAFDA8DF.jpg",
       "https://cdn.discordapp.com/attachments/933080307219972146/963417708681101352/Poland_Patch_Fix.mp4",
       "https://cdn.discordapp.com/attachments/933080307219972146/963233817567588422/IMG_8875.png",
       "https://cdn.discordapp.com/attachments/933080307219972146/962123271283814491/v09044g40000c96tqr3c77u7jamqputg.mp4",
       "https://cdn.discordapp.com/attachments/868469063066742836/960812642572849162/redditsave.com_i_wonder_what_this_will_do-c4o4ti4pi5r81.mp4",
       "https://cdn.discordapp.com/attachments/933080307219972146/960156934042972160/unknown.png",
       "https://cdn.discordapp.com/attachments/933080307219972146/959589717446373396/dankvideos-ttzfn2_1.mp4",
       "https://cdn.discordapp.com/attachments/933080307219972146/959091911174520872/videoplayback_1.mp4",
       "https://cdn.discordapp.com/attachments/933080307219972146/959034865741877308/funnylaugh.mp4",
       "https://cdn.discordapp.com/attachments/933080307219972146/958355049279524964/Screenshot_20220309-125950_YouTube.png",
       "https://cdn.discordapp.com/attachments/933080307219972146/957690148194254868/trim.5B895041-9395-4EA7-BDF9-102146BC7DE9.mov",
       "https://cdn.discordapp.com/attachments/933080307219972146/953948980432228372/59DF3795-DB73-48E3-9C5C-9580FF1AFC6F.png",
       "https://cdn.discordapp.com/attachments/933080307219972146/954017629276897320/IMG_1051.jpg",
       "https://cdn.discordapp.com/attachments/933080307219972146/954755925753864272/l_3HGf1ZsiYrgzrw.mp4",
       "https://cdn.discordapp.com/attachments/933080307219972146/954767746304987206/Snaptik_7051817098904866075_ngunyen-farrij-d.mp4",
       "https://cdn.discordapp.com/attachments/933080307219972146/954771020286398554/IMG_3762.jpg",
       "https://cdn.discordapp.com/attachments/933080307219972146/955766838833332284/IMG_5023.mp4",
       "https://cdn.discordapp.com/attachments/933080307219972146/956991007319261254/431C94D5-D8F9-4C2A-AD97-55DE0693BDB3.jpg",
       "https://cdn.discordapp.com/attachments/933080307219972146/951870809268424794/IMG_3734.jpg",
       "https://cdn.discordapp.com/attachments/933080307219972146/950861679988736071/20220308_175058.jpg",
       "https://cdn.discordapp.com/attachments/956994953727336448/970652414585749584/bright_bulb.mp4",
       "https://cdn.discordapp.com/attachments/634063767466147840/970980317072621589/dees_nutz.mp4",
       "https://cdn.discordapp.com/attachments/967031855985590383/971491098792951988/unknown.png",
       "https://cdn.discordapp.com/attachments/967031855985590383/971337260505137182/unknown.png",
       "https://cdn.discordapp.com/attachments/967031855985590383/971742044164882492/unknown-1.png",
       "https://cdn.discordapp.com/attachments/778442718551867402/934059960843780156/romanian_electricians.mp4",
       "https://cdn.discordapp.com/attachments/953513218666561556/971523058869338202/SHOOT_FASTERRRR.mp4",
       "https://cdn.discordapp.com/attachments/953513218666561556/971614368502538260/video0-71.mp4",
       "https://cdn.discordapp.com/attachments/326055605963980800/971537689545424936/unknown-43.png",
       "https://cdn.discordapp.com/attachments/967031855985590383/971742502900101160/VID-20210116-WA0001.mp4",
       "https://cdn.discordapp.com/attachments/967031855985590383/971742503470530600/SmartSelect_20210122-193502_Reddit.jpg",
       "https://cdn.discordapp.com/attachments/967031855985590383/971742503738953758/redditsave.com-idk_if_this_was_posted_here_before_but_i_saw_it-5167fx7o1ia61.mp4",
       "https://cdn.discordapp.com/attachments/967031855985590383/971742504007368784/IMG_20210127_143526.jpg",
       "https://cdn.discordapp.com/attachments/967031855985590383/971742570130595850/FB_IMG_1612170052868.png",
       "https://cdn.discordapp.com/attachments/967031855985590383/971742570587766844/image0-3.png",
       "https://media.discordapp.net/attachments/967031855985590383/971742570847817818/Screenshot_20210209-222730.png?width=619&height=670",
       "https://cdn.discordapp.com/attachments/967031855985590383/971742571149791322/t6wl0b7j1uk61.jpg",
       "https://media.discordapp.net/attachments/967031855985590383/971742714972491896/te1h7ome6se51.png?width=450&height=669",
       "https://cdn.discordapp.com/attachments/967031855985590383/971742716478259211/Screenshot_20210407-002404_Discord.jpg",
       "https://cdn.discordapp.com/attachments/967031855985590383/971742715987509278/fishboll.mp4",
       "https://cdn.discordapp.com/attachments/967031855985590383/971742716813770772/Smooth.png",
       "https://cdn.discordapp.com/attachments/967031855985590383/971742946221260840/Bigidiot.mp4",
       "https://cdn.discordapp.com/attachments/967031855985590383/971743051506655262/5tqwzrga8yw61.webp",
       "https://cdn.discordapp.com/attachments/967031855985590383/971743051783475300/image0-158.jpg",
       "https://cdn.discordapp.com/attachments/967031855985590383/971743357200126032/image0-8.jpg",
       "https://cdn.discordapp.com/attachments/967031855985590383/971743356961058896/Never-underestimate-a-duck.jpg",
       "https://cdn.discordapp.com/attachments/967031855985590383/971743356403220500/Screenshot_20210606-003453_Discord.jpg",
       "https://cdn.discordapp.com/attachments/967031855985590383/971743208142954506/Tumblr_l_2596640240616881.png",
       "https://cdn.discordapp.com/attachments/967031855985590383/971743207882911794/Screenshot_20210521-005009_Discord.jpg",
       "https://cdn.discordapp.com/attachments/967031855985590383/971743357476954143/Plate_Vending_Machine.mp4",
       "https://cdn.discordapp.com/attachments/967031855985590383/971830322696183808/IMG_1510.mp4",
       "https://media.discordapp.net/attachments/956994953727336448/971818648136187914/IMG_4102.jpg?width=378&height=669",
       "https://cdn.discordapp.com/attachments/764315477626454056/971549512596344853/redditsave.com_duck_runs_in_a_marathon_and_gets_a_medal-i9d9xaazjix81.mp4",
        };

        [Command("Memes")]
        [Description("Posts a random meme")]
        public async Task Meme(CommandContext ctx)
        {
            var random = new Random();
            int index = random.Next(meamea.Count);

            await ctx.Channel.SendMessageAsync(meamea[index]).ConfigureAwait(false);
            Console.WriteLine("Meme sendt successfully");
        }

        [Command("memecount")]
        [Description("Displays the amount of memes saved to this bot")]
        public async Task MemeCount(CommandContext ctx) 
        {
            await ctx.Channel.SendMessageAsync("There are " + meamea.Count + " memes saved").ConfigureAwait(false);
        }



    }

}


