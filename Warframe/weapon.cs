using System.Net;
using System.IO;
using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Warframe
{
    public class weapon
    {
        #region properties
        public string Name { get; set; }
        public string UniqueName { get; set; }
        public bool CodexSecret { get; set; }
        public double? SecondsPerShot { get; set; }
        public IList<float> DamagePerShot { get; set; }
        public ushort MagazineSize { get; set; }
        public float ReloadTime { get; set; }
        public float TotalDamage { get; set; }
        public ushort DamagePerSecond { get; set; }
        public string Trigger { get; set; }
        public string ParentName { get; set; }
        public float Accuracy { get; set; }
        public float CriticalChance { get; set; }
        public float CriticalMultiplier { get; set; }
        public float ProChance { get; set; }
        public float FireChance { get; set; }
        public byte ChargeAttack { get; set; }
        public byte SpinAttack { get; set; }
        public byte LeapAttack { get; set; }
        public byte WallAttack { get; set; }
        public byte Slot { get; set; }
        public string Noise { get; set; }
        public bool Sentinel { get; set; }
        public byte MasteryReq { get; set; }
        public float OmegaAttenuation { get; set; }
        #endregion

        #region Methods
        public static IList<weapon> Get(string name = null)
        {
            // Request.   
            WebRequest request = WebRequest.Create("http://content.warframe.com/MobileExport/Manifest/ExportWeapons.json");
            request.Credentials = CredentialCache.DefaultCredentials;
            request.Method = "GET";

            // Response
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            JObject data = JObject.Parse(reader.ReadToEnd());

            IList<weapon> WeaponList = new List<weapon>();

            double.Parse("1");

            Parallel.ForEach(data["ExportWeapons"], WeaponData =>
            {
                weapon Weapon = new weapon()
                {
                    Name = WeaponData["name"].ToString(),
                    UniqueName = WeaponData["uniqueName"].ToString(),
                    CodexSecret = bool.Parse(WeaponData["codexSecret"].ToString()),
                };

                if(WeaponData["secondsPerShot"] != null)
                {
                    Weapon.SecondsPerShot = double.Parse(WeaponData["secondsPerShot"].ToString());
                    Weapon.DamagePerShot = new List<float>();
                    Weapon.MagazineSize = ushort.Parse(WeaponData["magazineSize"].ToString());
                    Weapon.ReloadTime = float.Parse(WeaponData["reloadTime"].ToString());
                    Weapon.TotalDamage = float.Parse(WeaponData["totalDamage"].ToString());
                    Weapon.DamagePerSecond = ushort.Parse(WeaponData["damagePerSecond"].ToString());
                    Weapon.Trigger = WeaponData["trigger"].ToString();
                    Weapon.ParentName = WeaponData["description"].ToString();
                    Weapon.Accuracy = float.Parse(WeaponData["accuracy"].ToString());
                    Weapon.CriticalChance = float.Parse(WeaponData["criticalChance"].ToString());
                    Weapon.CriticalMultiplier = float.Parse(WeaponData["criticalMultiplier"].ToString());
                    Weapon.ProChance = float.Parse(WeaponData["procChance"].ToString());
                    Weapon.FireChance = float.Parse(WeaponData["fireRate"].ToString());
                    Weapon.ChargeAttack = byte.Parse(WeaponData["chargeAttack"].ToString());
                    Weapon.SpinAttack = byte.Parse(WeaponData["spinAttack"].ToString());
                    Weapon.LeapAttack = byte.Parse(WeaponData["leapAttack"].ToString());
                    Weapon.WallAttack = byte.Parse(WeaponData["wallAttack"].ToString());
                    Weapon.Slot = byte.Parse(WeaponData["slot"].ToString());
                    Weapon.Noise = WeaponData["noise"].ToString();
                    Weapon.Sentinel = bool.Parse(WeaponData["sentinel"].ToString());
                    Weapon.MasteryReq = byte.Parse(WeaponData["masteryReq"].ToString());
                    Weapon.OmegaAttenuation = float.Parse(WeaponData["omegaAttenuation"].ToString());

                    foreach (JValue value in WeaponData["damagePerShot"])
                    {
                        Weapon.DamagePerShot.Add(float.Parse(value.ToString()));
                    }
                } 

                try { 

                } catch(NullReferenceException)
                {

                }

                if (name != null)
                {
                    if (!Weapon.Name.Contains(name)) { return; }
                }

                WeaponList.Add(Weapon);
            });

            return WeaponList;
        }

        public static void DumpDebug(weapon weapon)
        {
            {
                Debug.WriteLine("{");
                Debug.WriteLine("   Name: " + weapon.Name);
                Debug.WriteLine("   UniqueName: " + weapon.UniqueName);
                Debug.WriteLine("   CodexSecret: " + weapon.CodexSecret);
                if (weapon.SecondsPerShot == null)
                {
                    Debug.WriteLine("   SecondsPerShot: " + weapon.SecondsPerShot);
                    Debug.Write("   DamagePerShot: [");
                    foreach (float value in weapon.DamagePerShot)
                    {
                        Debug.Write(" " + value + ",");
                    }
                    Debug.Write(" ]");
                    Debug.WriteLine("   MagazineSize: " + weapon.MagazineSize);
                    Debug.WriteLine("   ReloadTime: " + weapon.ReloadTime);
                    Debug.WriteLine("   TotalDamage: " + weapon.TotalDamage);
                    Debug.WriteLine("   DamagePerSecond: " + weapon.DamagePerSecond);
                    Debug.WriteLine("   Trigger: " + weapon.Trigger);
                    Debug.WriteLine("   ParentName: " + weapon.ParentName);
                    Debug.WriteLine("   Accuracy: " + weapon.Accuracy);
                    Debug.WriteLine("   CriticalChance: " + weapon.CriticalChance);
                    Debug.WriteLine("   CriticalMultiplier: " + weapon.CriticalMultiplier);
                    Debug.WriteLine("   ProChance: " + weapon.ProChance);
                    Debug.WriteLine("   FireChance: " + weapon.FireChance);
                    Debug.WriteLine("   ChargeAttack: " + weapon.ChargeAttack);
                    Debug.WriteLine("   SpinAttack: " + weapon.SpinAttack);
                    Debug.WriteLine("   LeapAttack: " + weapon.LeapAttack);
                    Debug.WriteLine("   WallAttack: " + weapon.WallAttack);
                    Debug.WriteLine("   Slot: " + weapon.Slot);
                    Debug.WriteLine("   Noise: " + weapon.Noise);
                    Debug.WriteLine("   Sentinel: " + weapon.Sentinel);
                    Debug.WriteLine("   MasteryReq: " + weapon.MasteryReq);
                    Debug.WriteLine("   OmegaAttenuation: " + weapon.OmegaAttenuation);
                }
                Debug.WriteLine("}");
            }
        }
        #endregion
    }
}