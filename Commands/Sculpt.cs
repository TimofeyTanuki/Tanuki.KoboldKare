using Photon.Pun;
using System.Globalization;
using Tanuki.KoboldKare.Models;
using UnityEngine;

namespace Tanuki.KoboldKare.Commands;

// The code for this command was decompiled and transferred with modifications. Cry.
internal class Sculpt : ICommand
{
    public string Name => "sculpt";
    public string[] Aliases => null;
    private class C__DisplayClass1_0
    {
        public bool set;
        public float modifier;
    }
    private void GetUsage()
    {
        Main.Instance.CheatsManager.AppendText("<color=grey>Usage: /sculpt <self/target> <dick/balls/boobs/height/fat/foodcapacity/bellycapacity/dickthickness/energy/hue/brightness/saturation/impregnate> [set] <modifier> (set is optional)</color>");
        return;
    }
    public void Execute(string[] Arguments)
    {
        Kobold k = (Kobold)PhotonNetwork.LocalPlayer.TagObject;
        if (Arguments.Length != 3 && Arguments.Length != 4)
        {
            GetUsage();
            return;
        }
        string text = Arguments[0];
        string text2 = Arguments[1];
        C__DisplayClass1_0 locals1 = new()
        {
            set = false,
            modifier = 0f
        };
        if (Arguments[2].ToLowerInvariant() == "set")
        {
            if (Arguments.Length != 4)
            {
                GetUsage();
                return;
            }
            locals1.set = true;
            if (!float.TryParse(Arguments[3], NumberStyles.Number, CultureInfo.InvariantCulture, out locals1.modifier))
            {
                Main.Instance.CheatsManager.AppendText($"<color=red>Invalid modifier: {Arguments[3]}</color>");
                return;
            }
        }
        else if (Arguments.Length != 3)
        {
            GetUsage();
            return;
        }
        else if (!float.TryParse(Arguments[2], NumberStyles.Number, CultureInfo.InvariantCulture, out locals1.modifier))
        {
            Main.Instance.CheatsManager.AppendText($"<color=red>Invalid modifier: {Arguments[2]}</color>");
            return;
        }
        Kobold kobold = null;
        if (text == "self")
        {
            kobold = k;
        }
        else if (text == "target")
        {
            Vector3 position = Camera.main.transform.position;
            Vector3 eyeDir = Camera.main.transform.forward;
            foreach (RaycastHit raycastHit in Physics.RaycastAll(position, eyeDir, 512f))
            {
                Kobold componentInParent = raycastHit.collider.GetComponentInParent<Kobold>();
                if (!(componentInParent == null) && !(componentInParent == k))
                {
                    kobold = componentInParent;
                    break;
                }
            }
            if (kobold == null)
            {
                Main.Instance.CheatsManager.AppendText("<color=red>Need to be facing the kobold you want to target with.</color>");
                return;
            }
        }
        else
        {
            GetUsage();
            return;
        }
        if (kobold == null)
        {
            Main.Instance.CheatsManager.AppendText("<color=red>No valid target.</color>");
            return;
        }
        kobold.photonView.RequestOwnership();
        KoboldGenes genes = kobold.GetGenes();
        string text3 = text2.ToLowerInvariant();
        uint num = ComputeStringHash(text3);
        if (num <= 3203931412U)
        {
            if (num <= 1698156692U)
            {
                if (num != 701255829U)
                {
                    if (num != 886071850U)
                    {
                        if (num == 1698156692U)
                        {
                            if (text3 == "dick")
                            {
                                GeneHolder geneHolder = kobold;
                                KoboldGenes koboldGenes = genes;
                                float? num2 = new float?(G__ApplyFloat(genes.dickSize, ref locals1));
                                float? num3 = null;
                                float? num4 = null;
                                float? num5 = null;
                                float? num6 = null;
                                float? num7 = num2;
                                float? num8 = null;
                                float? num9 = null;
                                float? num10 = null;
                                byte? b = null;
                                byte? b2 = b;
                                b = null;
                                byte? b3 = b;
                                b = null;
                                byte? b4 = b;
                                b = null;
                                byte? b5 = b;
                                float? num11 = null;
                                b = null;
                                byte? b6 = b;
                                b = null;
                                geneHolder.SetGenes(koboldGenes.With(num3, num4, num5, num6, num7, num8, num9, num10, b2, b3, b4, b5, num11, b6, b));
                                return;
                            }
                        }
                    }
                    else if (text3 == "brightness")
                    {
                        GeneHolder geneHolder2 = kobold;
                        KoboldGenes koboldGenes2 = genes;
                        byte? b = new byte?(G__SafeModify(genes.brightness, locals1.modifier, ref locals1));
                        float? num2 = null;
                        float? num12 = num2;
                        num2 = null;
                        float? num13 = num2;
                        num2 = null;
                        float? num14 = num2;
                        num2 = null;
                        float? num15 = num2;
                        num2 = null;
                        float? num16 = num2;
                        num2 = null;
                        float? num17 = num2;
                        num2 = null;
                        float? num18 = num2;
                        num2 = null;
                        float? num19 = num2;
                        byte? b7 = null;
                        byte? b8 = b;
                        byte? b9 = null;
                        byte? b10 = null;
                        num2 = null;
                        geneHolder2.SetGenes(koboldGenes2.With(num12, num13, num14, num15, num16, num17, num18, num19, b7, b8, b9, b10, num2, null, null));
                        return;
                    }
                }
                else if (text3 == "energy")
                {
                    GeneHolder geneHolder3 = kobold;
                    KoboldGenes koboldGenes3 = genes;
                    float? num20 = new float?(G__ApplyFloat(genes.maxEnergy, ref locals1));
                    float? num2 = null;
                    float? num21 = num2;
                    num2 = null;
                    float? num22 = num2;
                    num2 = null;
                    float? num23 = num2;
                    num2 = null;
                    float? num24 = num2;
                    num2 = null;
                    float? num25 = num2;
                    num2 = null;
                    float? num26 = num2;
                    num2 = null;
                    float? num27 = num2;
                    byte? b = null;
                    byte? b11 = b;
                    b = null;
                    byte? b12 = b;
                    b = null;
                    byte? b13 = b;
                    b = null;
                    byte? b14 = b;
                    num2 = null;
                    float? num28 = num2;
                    b = null;
                    byte? b15 = b;
                    b = null;
                    geneHolder3.SetGenes(koboldGenes3.With(num20, num21, num22, num23, num24, num25, num26, num27, b11, b12, b13, b14, num28, b15, b));
                    return;
                }
            }
            else if (num != 1948174501U)
            {
                if (num != 2031421831U)
                {
                    if (num == 3203931412U)
                    {
                        if (text3 == "fat")
                        {
                            GeneHolder geneHolder4 = kobold;
                            KoboldGenes koboldGenes4 = genes;
                            float? num2 = new float?(G__ApplyFloat(genes.fatSize, ref locals1));
                            float? num29 = null;
                            float? num30 = null;
                            float? num31 = num2;
                            float? num32 = null;
                            float? num33 = null;
                            float? num34 = null;
                            float? num35 = null;
                            float? num36 = null;
                            byte? b = null;
                            byte? b16 = b;
                            b = null;
                            byte? b17 = b;
                            b = null;
                            byte? b18 = b;
                            b = null;
                            byte? b19 = b;
                            float? num37 = null;
                            b = null;
                            byte? b20 = b;
                            b = null;
                            geneHolder4.SetGenes(koboldGenes4.With(num29, num30, num31, num32, num33, num34, num35, num36, b16, b17, b18, b19, num37, b20, b));
                            return;
                        }
                    }
                }
                else if (text3 == "bellycapacity")
                {
                    GeneHolder geneHolder5 = kobold;
                    KoboldGenes koboldGenes5 = genes;
                    float? num2 = new float?(G__ApplyFloat(genes.bellySize, ref locals1));
                    float? num38 = null;
                    float? num39 = null;
                    float? num40 = null;
                    float? num41 = null;
                    float? num42 = null;
                    float? num43 = null;
                    float? num44 = num2;
                    float? num45 = null;
                    byte? b = null;
                    byte? b21 = b;
                    b = null;
                    byte? b22 = b;
                    b = null;
                    byte? b23 = b;
                    b = null;
                    byte? b24 = b;
                    float? num46 = null;
                    b = null;
                    byte? b25 = b;
                    b = null;
                    geneHolder5.SetGenes(koboldGenes5.With(num38, num39, num40, num41, num42, num43, num44, num45, b21, b22, b23, b24, num46, b25, b));
                    return;
                }
            }
            else if (text3 == "foodcapacity")
            {
                GeneHolder geneHolder6 = kobold;
                KoboldGenes koboldGenes6 = genes;
                float? num2 = new float?(G__ApplyFloat(genes.metabolizeCapacitySize, ref locals1));
                float? num47 = null;
                float? num48 = null;
                float? num49 = null;
                float? num50 = null;
                float? num51 = null;
                float? num52 = null;
                float? num53 = null;
                float? num54 = num2;
                byte? b = null;
                byte? b26 = b;
                b = null;
                byte? b27 = b;
                b = null;
                byte? b28 = b;
                b = null;
                byte? b29 = b;
                float? num55 = null;
                b = null;
                byte? b30 = b;
                b = null;
                geneHolder6.SetGenes(koboldGenes6.With(num47, num48, num49, num50, num51, num52, num53, num54, b26, b27, b28, b29, num55, b30, b));
                return;
            }
        }
        else if (num <= 3585981250U)
        {
            if (num != 3552785031U)
            {
                if (num != 3560639797U)
                {
                    if (num == 3585981250U)
                    {
                        if (text3 == "height")
                        {
                            GeneHolder geneHolder7 = kobold;
                            KoboldGenes koboldGenes7 = genes;
                            float? num2 = new float?(G__ApplyFloat(genes.baseSize, ref locals1));
                            float? num56 = null;
                            float? num57 = num2;
                            float? num58 = null;
                            float? num59 = null;
                            float? num60 = null;
                            float? num61 = null;
                            float? num62 = null;
                            float? num63 = null;
                            byte? b = null;
                            byte? b31 = b;
                            b = null;
                            byte? b32 = b;
                            b = null;
                            byte? b33 = b;
                            b = null;
                            byte? b34 = b;
                            float? num64 = null;
                            b = null;
                            byte? b35 = b;
                            b = null;
                            geneHolder7.SetGenes(koboldGenes7.With(num56, num57, num58, num59, num60, num61, num62, num63, b31, b32, b33, b34, num64, b35, b));
                            return;
                        }
                    }
                }
                else if (text3 == "balls")
                {
                    GeneHolder geneHolder8 = kobold;
                    KoboldGenes koboldGenes8 = genes;
                    float? num2 = new float?(G__ApplyFloat(genes.ballSize, ref locals1));
                    float? num65 = null;
                    float? num66 = null;
                    float? num67 = null;
                    float? num68 = num2;
                    float? num69 = null;
                    float? num70 = null;
                    float? num71 = null;
                    float? num72 = null;
                    byte? b = null;
                    byte? b36 = b;
                    b = null;
                    byte? b37 = b;
                    b = null;
                    byte? b38 = b;
                    b = null;
                    byte? b39 = b;
                    float? num73 = null;
                    b = null;
                    byte? b40 = b;
                    b = null;
                    geneHolder8.SetGenes(koboldGenes8.With(num65, num66, num67, num68, num69, num70, num71, num72, b36, b37, b38, b39, num73, b40, b));
                    return;
                }
            }
            else if (text3 == "impregnate")
            {
                ReagentContents reagentContents = new(float.MaxValue);
                reagentContents.AddMix(ReagentDatabase.GetReagent("Cum").GetReagent(Mathf.Abs(locals1.modifier)), null);
                kobold.bellyContainer.AddMix(reagentContents, GenericReagentContainer.InjectType.Inject);
                return;
            }
        }
        else if (num <= 3817694041U)
        {
            if (num != 3741438406U)
            {
                if (num == 3817694041U)
                {
                    if (text3 == "hue")
                    {
                        GeneHolder geneHolder9 = kobold;
                        KoboldGenes koboldGenes9 = genes;
                        byte? b = new byte?(G__SafeModify(genes.hue, locals1.modifier, ref locals1));
                        float? num2 = null;
                        float? num74 = num2;
                        num2 = null;
                        float? num75 = num2;
                        num2 = null;
                        float? num76 = num2;
                        num2 = null;
                        float? num77 = num2;
                        num2 = null;
                        float? num78 = num2;
                        num2 = null;
                        float? num79 = num2;
                        num2 = null;
                        float? num80 = num2;
                        num2 = null;
                        float? num81 = num2;
                        byte? b41 = b;
                        byte? b42 = null;
                        byte? b43 = null;
                        byte? b44 = null;
                        num2 = null;
                        geneHolder9.SetGenes(koboldGenes9.With(num74, num75, num76, num77, num78, num79, num80, num81, b41, b42, b43, b44, num2, null, null));
                        return;
                    }
                }
            }
            else if (text3 == "dickthickness")
            {
                GeneHolder geneHolder10 = kobold;
                KoboldGenes koboldGenes10 = genes;
                float? num2 = new float?(G__ApplyFloat(genes.dickThickness, ref locals1));
                float? num82 = null;
                float? num83 = null;
                float? num84 = null;
                float? num85 = null;
                float? num86 = null;
                float? num87 = null;
                float? num88 = null;
                float? num89 = null;
                byte? b = null;
                byte? b45 = b;
                b = null;
                byte? b46 = b;
                b = null;
                byte? b47 = b;
                b = null;
                byte? b48 = b;
                float? num90 = num2;
                b = null;
                byte? b49 = b;
                b = null;
                geneHolder10.SetGenes(koboldGenes10.With(num82, num83, num84, num85, num86, num87, num88, num89, b45, b46, b47, b48, num90, b49, b));
                return;
            }
        }
        else if (num != 4121092745U)
        {
            if (num == 4156838336U)
            {
                if (text3 == "boobs")
                {
                    GeneHolder geneHolder11 = kobold;
                    KoboldGenes koboldGenes11 = genes;
                    float? num2 = new float?(G__ApplyFloat(genes.breastSize, ref locals1));
                    float? num91 = null;
                    float? num92 = null;
                    float? num93 = null;
                    float? num94 = null;
                    float? num95 = null;
                    float? num96 = num2;
                    float? num97 = null;
                    float? num98 = null;
                    byte? b = null;
                    byte? b50 = b;
                    b = null;
                    byte? b51 = b;
                    b = null;
                    byte? b52 = b;
                    b = null;
                    byte? b53 = b;
                    float? num99 = null;
                    b = null;
                    byte? b54 = b;
                    b = null;
                    geneHolder11.SetGenes(koboldGenes11.With(num91, num92, num93, num94, num95, num96, num97, num98, b50, b51, b52, b53, num99, b54, b));
                    return;
                }
            }
        }
        else if (text3 == "saturation")
        {
            GeneHolder geneHolder12 = kobold;
            KoboldGenes koboldGenes12 = genes;
            byte? b = new byte?(G__SafeModify(genes.saturation, locals1.modifier, ref locals1));
            float? num2 = null;
            float? num100 = num2;
            num2 = null;
            float? num101 = num2;
            num2 = null;
            float? num102 = num2;
            num2 = null;
            float? num103 = num2;
            num2 = null;
            float? num104 = num2;
            num2 = null;
            float? num105 = num2;
            num2 = null;
            float? num106 = num2;
            num2 = null;
            float? num107 = num2;
            byte? b55 = null;
            byte? b56 = null;
            byte? b57 = b;
            byte? b58 = null;
            num2 = null;
            geneHolder12.SetGenes(koboldGenes12.With(num100, num101, num102, num103, num104, num105, num106, num107, b55, b56, b57, b58, num2, null, null));
            return;
        }
        Main.Instance.CheatsManager.AppendText($"<color=red>Invalid body part specified: {Arguments[1]}</color>");
    }

    private byte G__SafeModify(byte value, float modifier, ref C__DisplayClass1_0 A_2)
    {
        int num = (int)((float)value + modifier);
        if (A_2.set)
        {
            num = (int)modifier;
        }
        if (num < 0)
        {
            return 0;
        }
        if (num > 255)
        {
            return byte.MaxValue;
        }
        return (byte)num;
    }
    private float G__ApplyFloat(float baseValue, ref C__DisplayClass1_0 A_1)
    {

        float num = baseValue + A_1.modifier;
        if (A_1.set)
        {
            num = A_1.modifier;
        }
        return Mathf.Max(num, 0.1f);
    }
    private uint ComputeStringHash(string s)
    {
        uint num = 0;
        if (s != null)
        {
            num = 2166136261U;
            for (int i = 0; i < s.Length; i++)
            {
                num = (s[i] ^ num) * 16777619U;
            }
        }
        return num;
    }
}