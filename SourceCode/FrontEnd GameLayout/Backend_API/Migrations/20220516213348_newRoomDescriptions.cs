using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend_API.Migrations
{
    public partial class newRoomDescriptions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "RoomDescriptions",
                keyColumn: "RoomDescriptionID",
                keyValue: 1,
                column: "Description",
                value: "1: The king has died of a magical curse caused by mysterious powers and a dooming presence is in store for the kingdom of Valirea. The threats of raids and magic power from foreign kingdoms are present and will end all of what you love and cherish. A strange oracle has foreseen that all this can be stopped if the Sword of Destiny is found and kept by the kingdom. The Sword of destiny is enchanted with holy powers and can protect the kingdom from evil. But to retrieve The Sword of Destiny, a mighty and brave warrior must face a trial in the lair of doom. It has been told that many have failed and perished in a attempt to retrieve the sword. You see no other choice and volunteer to save the kingdom of Valirea. You have entered the dark lair to retrieve the Sword of Destiny. The sheer cold and silence gives you discomforting feeling. You ask yourself, Is this really a good idea?. To move to the next room, use the arrow - keys or the move - buttons on the screen.");

            migrationBuilder.UpdateData(
                table: "RoomDescriptions",
                keyColumn: "RoomDescriptionID",
                keyValue: 2,
                column: "Description",
                value: "2. You hear a strange rumble. What is happening? The opening behind you begins to collapse. You sprint to avoid getting smashed by the falling rocks. There's no escape now! You stumble upon a rusty sword on the ground.Might be useful. Use the interact button to pick up found items. Found items can be located and equipped in the inventory. If you wish to view your character's stats, click the character-option.2");

            migrationBuilder.UpdateData(
                table: "RoomDescriptions",
                keyColumn: "RoomDescriptionID",
                keyValue: 3,
                column: "Description",
                value: "3. That was a strange encounter, but the naked gnoblin is no more. You've made it through to a room with lit torches on the walls. The lit torches reveals blood soaked walls and the thought of you becoming the next victim hits your thoughts.You stumble on a dusty shield in the corner of the room.Might be useful after that encounter.");

            migrationBuilder.UpdateData(
                table: "RoomDescriptions",
                keyColumn: "RoomDescriptionID",
                keyValue: 4,
                column: "Description",
                value: "4. The door revealed a tunnel that led to a poorly lit room. It stinks of rotten flesh and you want to move further into the lair. Which way do you want to go?");

            migrationBuilder.UpdateData(
                table: "RoomDescriptions",
                keyColumn: "RoomDescriptionID",
                keyValue: 5,
                column: "Description",
                value: "5. This room seems empty and dark. There are writings on the wall and a little door for what you assume is for a dwarf-like creature. You check it out and conclude you can squeeze yourself through the door.");

            migrationBuilder.UpdateData(
                table: "RoomDescriptions",
                keyColumn: "RoomDescriptionID",
                keyValue: 6,
                column: "Description",
                value: "6. The whelps corpse has a weird smell to it. The room leads to another door. What is behind it?");

            migrationBuilder.UpdateData(
                table: "RoomDescriptions",
                keyColumn: "RoomDescriptionID",
                keyValue: 7,
                column: "Description",
                value: "7. What is this? It looks like a cellar that hasn't been used for quite a while. A corpse is present behind the bars.The corpse has been there for a long time and has rotten down to mere bones.You stumble upon a key and a shield in the hands of the poor creature.Might be useful later.");

            migrationBuilder.UpdateData(
                table: "RoomDescriptions",
                keyColumn: "RoomDescriptionID",
                keyValue: 8,
                column: "Description",
                value: "8. This badly-lit corridor leads to a rusty door. What's behind it?");

            migrationBuilder.UpdateData(
                table: "RoomDescriptions",
                keyColumn: "RoomDescriptionID",
                keyValue: 9,
                column: "Description",
                value: "9. The room is empty, but leads to another door.");

            migrationBuilder.UpdateData(
                table: "RoomDescriptions",
                keyColumn: "RoomDescriptionID",
                keyValue: 10,
                column: "Description",
                value: "10. It seems you've stumpled upon a dining room. Skeletons are still seated at the table. What the hell happened here? You gaze upon the table and see a key. Might be useful later.");

            migrationBuilder.UpdateData(
                table: "RoomDescriptions",
                keyColumn: "RoomDescriptionID",
                keyValue: 11,
                column: "Description",
                value: "11. Wait, a well? A rope is attached to it so i can climb down. A door is also present. Which way will you go? Either option seems dangerous. ");

            migrationBuilder.UpdateData(
                table: "RoomDescriptions",
                keyColumn: "RoomDescriptionID",
                keyValue: 12,
                column: "Description",
                value: "12. The room is lit by a mysterious item in the middle. This seems important for your journey.");

            migrationBuilder.UpdateData(
                table: "RoomDescriptions",
                keyColumn: "RoomDescriptionID",
                keyValue: 13,
                column: "Description",
                value: "13. The dead naked Gnoblin looks horrendous. That's a sight you don't want to see again.");

            migrationBuilder.UpdateData(
                table: "RoomDescriptions",
                keyColumn: "RoomDescriptionID",
                keyValue: 14,
                column: "Description",
                value: "14. Ew. The room is filled by a stench of rotten flesh. A dead soldier lies in the corner with a battleaxe in hand. It seems well-crafted.");

            migrationBuilder.UpdateData(
                table: "RoomDescriptions",
                keyColumn: "RoomDescriptionID",
                keyValue: 15,
                column: "Description",
                value: "15. The door locks as you enter the room. Something mysterious is happening.");

            migrationBuilder.UpdateData(
                table: "RoomDescriptions",
                keyColumn: "RoomDescriptionID",
                keyValue: 16,
                column: "Description",
                value: "16. The corridor is split between two ways. Which way do you take?");

            migrationBuilder.UpdateData(
                table: "RoomDescriptions",
                keyColumn: "RoomDescriptionID",
                keyValue: 17,
                column: "Description",
                value: "17. The brute-gnoblin put up a good fight, but it is gone like the others. The room you entered is lit room with torches.");

            migrationBuilder.UpdateData(
                table: "RoomDescriptions",
                keyColumn: "RoomDescriptionID",
                keyValue: 18,
                column: "Description",
                value: "18. A door is present and you need a key. It might be somewhere else in the dungeon. You can sense an evil presence behind the door.");

            migrationBuilder.UpdateData(
                table: "RoomDescriptions",
                keyColumn: "RoomDescriptionID",
                keyValue: 19,
                column: "Description",
                value: "19. The Gnoblin king has been slayed. I can now retrieve the Sword of Destiny.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Username",
                keyValue: "Gamer1",
                column: "Password",
                value: "$2a$11$eBR2jvBORTwPn5i1fPnGn.8Z7zI4EwpPCbDul39D9ajjCthy/Rd32");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "RoomDescriptions",
                keyColumn: "RoomDescriptionID",
                keyValue: 1,
                column: "Description",
                value: "DB says: This is room 1");

            migrationBuilder.UpdateData(
                table: "RoomDescriptions",
                keyColumn: "RoomDescriptionID",
                keyValue: 2,
                column: "Description",
                value: "DB says: This is room 2");

            migrationBuilder.UpdateData(
                table: "RoomDescriptions",
                keyColumn: "RoomDescriptionID",
                keyValue: 3,
                column: "Description",
                value: "DB says: This is room 3");

            migrationBuilder.UpdateData(
                table: "RoomDescriptions",
                keyColumn: "RoomDescriptionID",
                keyValue: 4,
                column: "Description",
                value: "DB says: This is room 4");

            migrationBuilder.UpdateData(
                table: "RoomDescriptions",
                keyColumn: "RoomDescriptionID",
                keyValue: 5,
                column: "Description",
                value: "DB says: This is room 5");

            migrationBuilder.UpdateData(
                table: "RoomDescriptions",
                keyColumn: "RoomDescriptionID",
                keyValue: 6,
                column: "Description",
                value: "DB says: This is room 6");

            migrationBuilder.UpdateData(
                table: "RoomDescriptions",
                keyColumn: "RoomDescriptionID",
                keyValue: 7,
                column: "Description",
                value: "DB says: This is room 7");

            migrationBuilder.UpdateData(
                table: "RoomDescriptions",
                keyColumn: "RoomDescriptionID",
                keyValue: 8,
                column: "Description",
                value: "DB says: This is room 8");

            migrationBuilder.UpdateData(
                table: "RoomDescriptions",
                keyColumn: "RoomDescriptionID",
                keyValue: 9,
                column: "Description",
                value: "DB says: This is room 9");

            migrationBuilder.UpdateData(
                table: "RoomDescriptions",
                keyColumn: "RoomDescriptionID",
                keyValue: 10,
                column: "Description",
                value: "DB says: This is room 10");

            migrationBuilder.UpdateData(
                table: "RoomDescriptions",
                keyColumn: "RoomDescriptionID",
                keyValue: 11,
                column: "Description",
                value: "DB says: This is room 11");

            migrationBuilder.UpdateData(
                table: "RoomDescriptions",
                keyColumn: "RoomDescriptionID",
                keyValue: 12,
                column: "Description",
                value: "DB says: This is room 12");

            migrationBuilder.UpdateData(
                table: "RoomDescriptions",
                keyColumn: "RoomDescriptionID",
                keyValue: 13,
                column: "Description",
                value: "DB says: This is room 13");

            migrationBuilder.UpdateData(
                table: "RoomDescriptions",
                keyColumn: "RoomDescriptionID",
                keyValue: 14,
                column: "Description",
                value: "DB says: This is room 14");

            migrationBuilder.UpdateData(
                table: "RoomDescriptions",
                keyColumn: "RoomDescriptionID",
                keyValue: 15,
                column: "Description",
                value: "DB says: This is room 15");

            migrationBuilder.UpdateData(
                table: "RoomDescriptions",
                keyColumn: "RoomDescriptionID",
                keyValue: 16,
                column: "Description",
                value: "DB says: This is room 16");

            migrationBuilder.UpdateData(
                table: "RoomDescriptions",
                keyColumn: "RoomDescriptionID",
                keyValue: 17,
                column: "Description",
                value: "DB says: This is room 17");

            migrationBuilder.UpdateData(
                table: "RoomDescriptions",
                keyColumn: "RoomDescriptionID",
                keyValue: 18,
                column: "Description",
                value: "DB says: This is room 18");

            migrationBuilder.UpdateData(
                table: "RoomDescriptions",
                keyColumn: "RoomDescriptionID",
                keyValue: 19,
                column: "Description",
                value: "DB says: This is room 19");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Username",
                keyValue: "Gamer1",
                column: "Password",
                value: "$2a$11$jW9/.SbTTKvoUx1sCVOtZON9Jctx9Caai9BTwNxp1tgqyZfQ5.HJ6");
        }
    }
}
