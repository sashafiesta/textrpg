using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpg
{
    class Damage
    {
        public double amount;
        public DamageType type;
        public Damage(double amount_, DamageType type_)
        {
            amount = amount_;
            type = type_;
        }
        public enum DamageType : byte
        {
            Generic, //Обычный
            Piercing, //Колющий
            Slashing, //Рубящий
            Crushing, //Дробящий
            Acid, //Кислотный
            Cold, //Холодом
            Fire, //Огненный
            Force, //Ударной волной
            Electrical, //Электричеством
            Necrotic, //Некротический
            Poison, //Ядовитый
            Psychic, //Психический
            Audial, //Звуковой
            Radiational, //Радиационный
            Starving, //Голодом
            Thirst, //Жаждой
            Suffocating, //От отсутствия кислорода
            Bleeding, //От истекания кровью
            Illness //От болезни
        }
    }
}
